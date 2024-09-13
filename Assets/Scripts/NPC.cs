 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Controller
{
    public bool possessed = false;

    void Update()
    {
        if (possessed)
        {
            Debug.Log("Moving npc");
            Move();
            if (Input.GetButtonDown("Gameboy A"))
            {
                // kill
            }

            if (Input.GetButtonDown("Gameboy B"))
            {
                // unpossess
            }
        }
    }
}
