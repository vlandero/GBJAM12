using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionSphere : MonoBehaviour
{
    [HideInInspector] public NPC npc;
    public Interactable interactable;
    private void Start()
    {
        npc = GetComponentInParent<NPC>();
    }

    private void Update()
    {
        if (npc.possessed)
        {
            if (Input.GetButtonDown("Gameboy B"))
            {
                if (interactable)
                {
                    if (interactable.interactPermissions == npc.possessableType)
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
