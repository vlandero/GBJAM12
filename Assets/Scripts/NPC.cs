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
    public ColorNames _colorname;

    private NPCMovement npcMovement;

    protected override void Start()
    {
        base.Start();
        possessText.enabled = false;
        killText.enabled = false;
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
        npcMovement = GetComponent<NPCMovement>();
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
            }

            if (Input.GetButtonDown("Gameboy B"))
            {
                // kill
            }
        }
    }
}
