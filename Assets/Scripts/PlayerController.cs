using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    private Possessable possessableToInteract = null;
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
        if (possessing && !possessableToInteract.possessed)
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
                if (possessableToInteract)
                {
                    possessableToInteract.canMove = false;
                    _animator.SetBool("Possess", true);
                    possessing = true;
                    canPossess = false;
                    possessableToInteract.body.GetComponent<BoxCollider2D>().enabled = true;
                    possessableToInteract.possessed = true;
                    rb.velocity = Vector3.zero;
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
        if (!(possessableToInteract == null && canPossess)) return;
        var interactionSphere = collision.GetComponent<PossessableInteractionSphere>();
        if (interactionSphere)
        {
            possessableToInteract = interactionSphere.possessable;
            possessableToInteract.highlight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactionSphere = collision.GetComponent<PossessableInteractionSphere>();
        if (!(canPossess && interactionSphere && possessableToInteract && possessableToInteract.name == interactionSphere.possessable.name)) return;
        possessableToInteract.highlight.SetActive(false);
        possessableToInteract = null;
    }

    private void Possess() // functie apelata de animatie, cand se termina animatia
    {
        possessableToInteract.canMove = true; // s a terminat animatia, deci possessable se poate misca
        _animator.SetBool("Possess", false);
        ColorManager.Instance.ColorChange(possessableToInteract._colorname);
        rb.velocity = Vector3.zero;
        body.SetActive(false);
        NPC npcToInteract = possessableToInteract.gameObject.GetComponent<NPC>();
        if (npcToInteract && npcToInteract.scarable)
        {
            npcToInteract.fearBox.SetActive(true);
            npcToInteract.fearBoxAnimator.SetBool("possessed", true);
        }
    }
}
