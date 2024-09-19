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

    [Header("Modifiers")]
    public bool isFinalTarget = false;


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
        if (!possessed)
        {
            if (_animator != null && (Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f))
            {
                _animator.SetFloat("X", rb.velocity.x);
                _animator.SetFloat("Y", rb.velocity.y);
            }
        }
        if (_animator != null)
        {
            if ((Mathf.Abs(rb.velocity.x) < .1f && Mathf.Abs(rb.velocity.y) < .1f))
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
