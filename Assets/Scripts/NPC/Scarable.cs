using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarable : MonoBehaviour
{
    [HideInInspector] public bool canBeScared = false; // variabila pentru a tine evidenta daca am intrat in npc deja, ca sa poata fi speriat ulterior
    [HideInInspector] public NPC npcComponent;
    public int pointsForScaring = 10;

    private void Start()
    {
        npcComponent = GetComponent<NPC>();
    }

    public virtual void Scare() 
    {
        if(canBeScared && !npcComponent.possessed)
        {
            if (npcComponent.isFinalTarget && SpookyManager.Instance.valueToReachForScaringTarget > SpookyManager.Instance._points)
            {
                return;
            }
            else
            {
                // afisam ecran win
                Debug.Log("YOU WIN!!!");
            }
            npcComponent.scared = true;
            npcComponent.highlight.SetActive(false);
            SpookyManager.Instance.AddPoints(pointsForScaring);
            Debug.Log(name + " was scared!!!");
        }
    }
}
