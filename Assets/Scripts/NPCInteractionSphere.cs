using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionSphere : MonoBehaviour
{
    public NPC npc;
    private void Start()
    {
        npc = GetComponentInParent<NPC>();
    }
}
