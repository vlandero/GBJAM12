using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] private FlashingLight affectedLightArea;

    protected override void Start()
    {
        base.Start();
        affectedLightArea.SwitchOff();
    }

    public override void Interact()
    {
        if (affectedLightArea.animPlaying) return;
        affectedLightArea.SwitchOn();
        affectedLightArea.animator.SetTrigger("Flicker");
    }
}
