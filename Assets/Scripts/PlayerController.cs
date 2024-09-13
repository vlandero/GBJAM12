using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    private NPC npcToInteract = null;
    private bool possessing = false;
    void Update()
    {
        if (!possessing)
        {
            Move();
            if (Input.GetButtonDown("Gameboy A"))
            {
                if (npcToInteract)
                {
                    possessing = true;
                    npcToInteract.possessed = true;
                }
            }

            if (Input.GetButtonDown("Gameboy B"))
            {

            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (npcToInteract != null) return;
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if (npcComponent)
        {
            npcToInteract = npcComponent.npc;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if (!(npcComponent && npcToInteract.name == npcComponent.npc.name)) return;
        npcToInteract = null;
    }
}
