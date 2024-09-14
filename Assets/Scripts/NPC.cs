 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Controller // ACEST SCRIPT E RULAT INAINTE DE PLAYERCONTROLLER!!!!
{
    public bool possessed = false;
    public TextMeshProUGUI possessText;
    public TextMeshProUGUI killText;
    public GameObject body;

    private NPCMovement npcMovement;

    public NPC npcToKill = null;

    public NPCInteractionSphere npcInteractionSphere;

    protected override void Start()
    {
        base.Start();
        possessText.enabled = false;
        killText.enabled = false;
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
        npcMovement = GetComponent<NPCMovement>();
        npcInteractionSphere = GetComponentInChildren<NPCInteractionSphere>();
    }

    void Update()
    {
        if(PauseManager.Instance.isPaused) return;
        if (possessed)
        {
            Move();
            GameManager.Instance.playerController.transform.position = body.transform.position;
            if (Input.GetButtonDown("Gameboy A"))
            {
                possessed = false;
                body.GetComponent<BoxCollider2D>().enabled = false;
                rb.velocity = Vector3.zero;
                npcMovement.SetRandomDestination();
                npcInteractionSphere.gameObject.SetActive(true);
                if (npcToKill)
                {
                    npcToKill.killText.enabled = false;
                    npcToKill = null;
                }
            }

            if (Input.GetButtonDown("Gameboy B"))
            {
                Debug.Log("Killing");
                if (npcToKill)
                {
                    Destroy(npcToKill.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!possessed) return;
        if (!(npcToKill == null)) return;
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if (npcComponent)
        {
            npcToKill = npcComponent.npc;
            npcToKill.killText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(possessed && npcToKill)) return;
        var npcComponent = collision.GetComponent<NPCInteractionSphere>();
        if (!(npcComponent && npcToKill.name == npcComponent.npc.name)) return;
        npcToKill.killText.enabled = false;
        npcToKill = null;
    }
}
