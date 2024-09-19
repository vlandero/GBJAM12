using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public bool animPlaying = false;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NPCInteractionSphere npc = collision.GetComponent<NPCInteractionSphere>();
        if (npc)
        {
            if (npc.npc.scarable && npc.npc.scarable.GetComponent<LightScarable>())
            {
                npc.npc.scarable.Scare();
            }
        }
    }

    public void SwitchOff()
    {
        Debug.Log("SSS");
        animPlaying = false;
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
    }

    public void SwitchOn()
    {
        Debug.Log("SSS ON");
        animPlaying = true;
        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
    }
}
