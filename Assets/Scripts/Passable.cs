using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passable : MonoBehaviour
{
    public List<PossessableType> passableBy = new List<PossessableType>();

    private void Start()
    {
        foreach(NPC npc in GameManager.Instance.npcs)
        {
            if(passableBy.Contains(npc.possessableType))
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), npc.body.GetComponent<Collider2D>());
            }
        }
    }
}
