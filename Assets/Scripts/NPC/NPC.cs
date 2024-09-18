 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Possessable // ACEST SCRIPT E RULAT INAINTE DE PLAYERCONTROLLER!!!!
{
    [HideInInspector] public NPCInteractionSphere npcInteractionSphere;

    [HideInInspector] public Scarable scarable;

    public GameObject fearBox;
    public Animator fearBoxAnimator;

    protected override void Start()
    {
        base.Start();
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
        npcInteractionSphere = GetComponentInChildren<NPCInteractionSphere>();
        scarable = GetComponent<Scarable>();
        fearBox.SetActive(false);
    }

    public override void UnPossess()
    {
        base.UnPossess();
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
