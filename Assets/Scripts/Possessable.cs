using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Possessable : Controller
{
    public PossessableType possessableType = PossessableType.npc;
    public ColorNames _colorname;
    [HideInInspector] public bool possessed = false;
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool canMove = false;
    [HideInInspector] public GameObject body;
    public NPC npcToInteract = null;
    public Interactable objectInteractable = null;
    protected override void Start()
    {
        base.Start();
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
    }

    void Update()
    {
        if (PauseManager.Instance.isPaused) return;
        if (possessed)
        {
            if (canMove)
            {
                Move();
                GameManager.Instance.playerController.transform.position = body.transform.position;
            }
            else
            {
                GameManager.Instance.playerController.transform.position = body.transform.position + new Vector3(0, -0.01f);
            }
            if (Input.GetButtonDown("Gameboy A"))
            {
                UnPossess();
            }

            if (Input.GetButtonDown("Gameboy B"))
            {
                if (npcToInteract)
                {
                    ObjectScarable objectScarable = npcToInteract.GetComponent<ObjectScarable>();
                    if (objectScarable && objectScarable.scarableBy == possessableType)
                    {
                        Debug.Log("Scaring");
                        objectScarable.Scare();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!possessed) return;
        if (npcToInteract == null)
        {
            var npcComponent = collision.GetComponent<NPCInteractionSphere>();
            if (npcComponent)
            {
                npcToInteract = npcComponent.npc;
                // enable highlight
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(possessed && (npcToInteract || objectInteractable))) return;
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if ((npcComponent && npcToInteract.name == npcComponent.npc.name))
        {
            npcToInteract = null;
            // disable highlight
        }
    }

    public virtual void UnPossess()
    {
        possessed = false;
        body.GetComponent<BoxCollider2D>().enabled = false;
        rb.velocity = Vector3.zero;
        if (npcToInteract)
        {
            // disable highlight
            npcToInteract = null;
        }
    }
}
