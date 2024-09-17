using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionSphere : PossessableInteractionSphere
{
    [HideInInspector] public Interactable interactable;
    [HideInInspector] public NPC npc;

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
                    if (interactable.interactPermissions == possessable.possessableType)
                    {
                        Debug.Log("Interacting");
                        interactable.Interact();
                    }
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var objectComponent = collision.GetComponent<Interactable>();
        if (objectComponent && objectComponent.name == interactable.name)
        {
            interactable = null;
            // disable highlight
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactable == null)
        {
            var objectComponent = collision.GetComponent<Interactable>();
            if (objectComponent)
            {
                interactable = objectComponent;
                // enable highlight
            }
        }
    }
}
