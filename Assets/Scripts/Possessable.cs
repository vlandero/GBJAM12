using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Possessable : Controller
{
    [Header("Possessable - Modifiers")]
    public PossessableType possessableType = PossessableType.npc;
    public ColorNames _colorname;
    [HideInInspector] public bool possessed = false;
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool canMove = false;
    [HideInInspector] public NPC npcToInteract = null;

    [Header("Possessable - References")]
    public GameObject body;
    public GameObject highlight;
    protected override void Start()
    {
        base.Start();
        highlight.SetActive(false);
    }

    protected virtual void FixedUpdate()
    {
        if (possessed)
        {
            if (canMove) Move();
        }
    }

    protected virtual void Update()
    {
        if (PauseManager.Instance.isPaused) return;
        if (possessed)
        {
            if (canMove)
            {
                GameManager.Instance.playerController.transform.position = body.transform.position;
            }
            else
            {
                GameManager.Instance.playerController.transform.position = body.transform.position + new Vector3(0, -0.01f);
            }
        }
        if (possessed)
        {
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
                        objectScarable.Scare();
                        npcToInteract = null;
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
            if (npcComponent && !npcComponent.npc.scared)
            {
                npcToInteract = npcComponent.npc;
                npcToInteract.highlight.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(possessed && npcToInteract)) return;
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if ((npcComponent && npcToInteract.name == npcComponent.npc.name))
        {
            npcToInteract.highlight.SetActive(false);
            npcToInteract = null;
        }
    }

    public virtual void UnPossess()
    {
        if (GameManager.Instance.playerController.playingAnim) return;
        possessed = false;
        body.GetComponent<BoxCollider2D>().enabled = false;
        rb.velocity = Vector3.zero;
        if (npcToInteract)
        {
            highlight.SetActive(false);
            npcToInteract.highlight.SetActive(false);
            npcToInteract = null;
        }
    }
}
