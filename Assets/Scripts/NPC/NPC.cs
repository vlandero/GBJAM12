 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Possessable // ACEST SCRIPT E RULAT INAINTE DE PLAYERCONTROLLER!!!!
{
    private NPCMovement npcMovement;
    [HideInInspector] public NPCInteractionSphere npcInteractionSphere;

    [HideInInspector] public Scarable scarable;

    public GameObject fearBox;
    public Animator fearBoxAnimator;

    protected override void Start()
    {
        base.Start();
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
        npcMovement = GetComponent<NPCMovement>();
        npcInteractionSphere = GetComponentInChildren<NPCInteractionSphere>();
        scarable = GetComponent<Scarable>();
        if(scarable) fearBox.SetActive(false);
    }

    public override void UnPossess()
    {
        base.UnPossess();
        npcMovement.SetRandomDestination();
        if (scarable)
        {
            scarable.canBeScared = true;
            fearBoxAnimator.SetBool("possessed", false);
            fearBox.SetActive(false);
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Virtual interact");
    }

    protected override void Update()
    {
        base.Update();
    }
}
