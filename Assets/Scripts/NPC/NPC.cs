 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Possessable // ACEST SCRIPT E RULAT INAINTE DE PLAYERCONTROLLER!!!!
{
    private NPCMovement npcMovement;
    [HideInInspector] public NPCInteractionSphere npcInteractionSphere;

    [HideInInspector] public Scarable scarable;

    protected override void Start()
    {
        base.Start();
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
        npcMovement = GetComponent<NPCMovement>();
        npcInteractionSphere = GetComponentInChildren<NPCInteractionSphere>();
        scarable = GetComponent<Scarable>();
    }

    public override void UnPossess()
    {
        base.UnPossess();
        npcMovement.SetRandomDestination();
        if(scarable) scarable.canBeScared = true;
    }

    public virtual void Interact()
    {
        Debug.Log("Virtual interact");
    }
}
