 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Possessable // ACEST SCRIPT E RULAT INAINTE DE PLAYERCONTROLLER!!!!
{
    [HideInInspector] public NPCInteractionSphere npcInteractionSphere;

    [HideInInspector] public Scarable scarable;

    [HideInInspector] public bool scared = false;


    [Header("NPC - References")]
    public GameObject fearBox;
    public Animator fearBoxAnimator;
    public GameObject scareSign;
    public GameObject targetArrow;

    [Header("NPC - Modifiers")]
    public bool isFinalTarget = false;


    protected override void Start()
    {
        base.Start();
        npcInteractionSphere = GetComponentInChildren<NPCInteractionSphere>();
        scarable = GetComponent<Scarable>();
        fearBox.SetActive(false);
        scareSign.SetActive(false);

        if (!isFinalTarget)
        {
            targetArrow.SetActive(false);
        }
    }

    public override void UnPossess()
    {
        base.UnPossess();
        if (GameManager.Instance.playerController.playingAnim) return;
        if (npcInteractionSphere.interactable)
        {
            npcInteractionSphere.interactable.highlight.SetActive(false);
            npcInteractionSphere.interactable = null;
        }
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
        if (!possessed)
        {
            if (_animator != null && (Mathf.Abs(rb.velocity.x) > 0.2f || Mathf.Abs(rb.velocity.y) > 0.2f))
            {
                var xHigher = Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y);
                _animator.SetFloat("X", xHigher ? rb.velocity.x : 0);
                _animator.SetFloat("Y", !xHigher ? rb.velocity.y : 0);
            }
        }
        if (_animator != null)
        {
            if ((Mathf.Abs(rb.velocity.x) < 0.2f && Mathf.Abs(rb.velocity.y) < 0.2f))
            {
                _animator.SetBool("Idle", true);
            }
            else
            {
                _animator.SetBool("Idle", false);
            }
        }
    }

    public void GetPossessed()
    {
        _animator.SetBool("Possess", false);
    }
}
