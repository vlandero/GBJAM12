using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarable : MonoBehaviour
{
    [HideInInspector] public bool canBeScared = false; // variabila pentru a tine evidenta daca am intrat in npc deja, ca sa poata fi speriat ulterior
    [HideInInspector] public NPC npcComponent;

    private void Start()
    {
        npcComponent = GetComponent<NPC>();
    }

    public virtual void Scare() 
    {
        if(canBeScared && !npcComponent.possessed)
        {
            npcComponent.scared = true;
            npcComponent.highlight.SetActive(false);
            Debug.Log(name + " was scared!!!");
        }
    }
}
