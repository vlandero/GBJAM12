using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NPCInteractionSphere npc = collision.GetComponent<NPCInteractionSphere>();
        if (npc)
        {
            if (npc.npc.scarable && npc.npc.scarable.GetComponent<LightScarable>())
            {
                npc.npc.scarable.Scare();
            }
        }
    }
}
