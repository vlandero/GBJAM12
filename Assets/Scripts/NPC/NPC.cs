 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Possessable // ACEST SCRIPT E RULAT INAINTE DE PLAYERCONTROLLER!!!!
{
    [HideInInspector] public NPCInteractionSphere npcInteractionSphere;

    [HideInInspector] public Scarable scarable;

    [HideInInspector] public bool scared = false;

    public GameObject fearBox;
    public Animator fearBoxAnimator;
    public GameObject scareSign;

    protected override void Start()
    {
        base.Start();
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
        npcInteractionSphere = GetComponentInChildren<NPCInteractionSphere>();
        scarable = GetComponent<Scarable>();
        fearBox.SetActive(false);
        scareSign.SetActive(false);
    }

    public override void UnPossess()
    {
        base.UnPossess();
        if (GameManager.Instance.playerController.playingAnim) return;
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
