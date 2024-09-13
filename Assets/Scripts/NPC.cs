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

    protected override void Start()
    {
        base.Start();
        possessText.enabled = false;
        killText.enabled = false;
        body = GetComponentInChildren<SpriteRenderer>().gameObject;
    }

    void Update()
    {
        if (possessed)
        {
            Move();
            GameManager.Instance.playerController.transform.position = body.transform.position;
            if (Input.GetButtonDown("Gameboy A"))
            {
                possessed = false;
                rb.velocity = Vector3.zero;
            }

            if (Input.GetButtonDown("Gameboy B"))
            {
                // kill
            }
        }
    }
}
