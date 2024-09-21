using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionSphere : PossessableInteractionSphere
{
    [HideInInspector] public Interactable interactable;
    [HideInInspector] public NPC npc; // doar pentru get

    protected override void Start()
    {
        base.Start();
        npc = possessable.gameObject.GetComponent<NPC>();
    }

    private void Update()
    {
        if (possessable.possessed)
        {
            if (Input.GetButtonDown("Gameboy B"))
            {
                if (interactable)
                {
                    if (interactable.interactPermissions.Contains(possessable.possessableType))
                    {
                        interactable.Interact();
                    }
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var objectComponent = collision.GetComponent<Interactable>();
        if (interactable && objectComponent && objectComponent.name == interactable.name)
        {
            interactable.highlight.SetActive(false);
            interactable = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (npc.possessed && interactable == null)
        {
            var objectComponent = collision.GetComponent<Interactable>();
            if (objectComponent)
            {
                interactable = objectComponent;
                interactable.highlight.SetActive(true);
            }
        }
    }
}
