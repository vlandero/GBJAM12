using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    private NPC npcToInteract = null;
    [HideInInspector] public bool possessing = false;

    [HideInInspector] public bool canPossess = true;
    [HideInInspector] public GameObject body;

    protected override void Start()
    {
        base.Start();
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
    }
    void Update()
    {
        if (Input.GetButtonDown("Gameboy Start"))
        {
            rb.velocity = Vector3.zero;
            PauseManager.Instance.TogglePause();
        }
        if (PauseManager.Instance.isPaused) return;
        if (possessing && !npcToInteract.possessed)
        {
            ColorManager.Instance.ColorChange(ColorNames.ghost);
            possessing = false;
            canPossess = true;
            body.SetActive(true);
        }
        else if (!possessing)
        {
            Move();
            if (Input.GetButtonDown("Gameboy A"))
            {
                if (npcToInteract)
                {
                    _animator.SetBool("Possess", true);
                    possessing = true;
                    canPossess = false;
                    npcToInteract.body.GetComponent<BoxCollider2D>().enabled = true;
                    npcToInteract.possessed = true;
                    rb.velocity = Vector3.zero;
                    npcToInteract.canMove = false;
                }
            }

            if (Input.GetButtonDown("Gameboy B"))
            {
                // select level?
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if (!(canPossess && npcComponent && npcToInteract && npcToInteract.name == npcComponent.npc.name)) return;
        npcToInteract = null;
    }

    private void Possess()
    {
         npcToInteract.canMove = true;
        _animator.SetBool("Possess", false);
        ColorManager.Instance.ColorChange(npcToInteract._colorname);
        rb.velocity = Vector3.zero;
        body.SetActive(false);
    }
}
