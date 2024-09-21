using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MenuButton
{
    public int volume = 5;
    protected override void Start()
    {
        base.Start();
        // set sound from PlayerPrefs
        if (PlayerPrefs.HasKey("Sound"))
        {
            volume = PlayerPrefs.GetInt("Sound");
        }
        else
        {
            PlayerPrefs.SetInt("Sound", volume);
        }
        textMeshProUGUI.text = "Sound " + volume + "%";

    }
    protected override void Update()
    {
        base.Update();
        if(!selected) return;
        textMeshProUGUI.text = "Sound " + volume + "%";
        if(Input.GetButtonDown("Gameboy Left"))
        {
            volume = Mathf.Clamp(volume - 5, 0, 100);
            PlayerPrefs.SetInt("Sound", volume);
        }
        if (Input.GetButtonDown("Gameboy Right"))
        {
            volume = Mathf.Clamp(volume + 5, 0, 100);
            PlayerPrefs.SetInt("Sound", volume);
        }
    }

    public override void Press()
    {

    }
}
