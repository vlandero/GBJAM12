using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    private NPC npcToInteract = null;
    public bool possessing = false;

    public bool canPossess = true;
    public GameObject body;

    protected override void Start()
    {
        base.Start();
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
    }
    void Update()
    {
        if (possessing && !npcToInteract.possessed)
        {
            possessing = false;
            canPossess = true;
        }
        else if (!possessing)
        {
            Move();
            if (Input.GetButtonDown("Gameboy A"))
            {
                if (npcToInteract)
                {
                    npcToInteract.possessText.enabled = false;
                    possessing = true;
                    npcToInteract.possessed = true;
                    canPossess = false;
                    rb.velocity = Vector3.zero;
                }
            }

            if (Input.GetButtonDown("Gameboy B"))
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(npcToInteract == null && canPossess)) return;
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if (npcComponent)
        {
            npcToInteract = npcComponent.npc;
            npcToInteract.possessText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if (!(canPossess && npcComponent && npcToInteract.name == npcComponent.npc.name)) return;
        npcToInteract.possessText.enabled = false;
        npcToInteract = null;
    }
}
