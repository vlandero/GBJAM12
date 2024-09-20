using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionSphere : MonoBehaviour
{
    public Passable passable;

    [HideInInspector] public List<NPC> npcsInRange = new ();
    private bool closedDoor = true;
    [HideInInspector] public bool animationPlaying = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var npcInteractionSphere = collision.GetComponent<NPCInteractionSphere>();
        if (npcInteractionSphere && passable.animator && passable.passableBy.Contains(npcInteractionSphere.npc.possessableType))
        {
            npcsInRange.Add(npcInteractionSphere.npc);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var npcInteractionSphere = collision.GetComponent<NPCInteractionSphere>();
        if (npcInteractionSphere && passable.animator && passable.passableBy.Contains(npcInteractionSphere.npc.possessableType))
        {
            npcsInRange.Remove(npcInteractionSphere.npc);
        }
    }

    private void Update()
    {
        if (animationPlaying) return;
        if (closedDoor && npcsInRange.Count > 0)
        {
            closedDoor = false;
            animationPlaying = true;
            passable.animator.SetBool("Open", true);
        }
        else if(!closedDoor && npcsInRange.Count == 0)
        {
            closedDoor = true;
            animationPlaying = true;
            passable.animator.SetBool("Open", false);
        }
    }
}
