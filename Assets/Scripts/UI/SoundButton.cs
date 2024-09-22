using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MenuButton
{
    public float volume = 5;

    private MusicManager musicManager;

    [SerializeField] private GameObject soundControlObj;
    protected override void Start()
    {
        base.Start();
        musicManager = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
        if(!musicManager._audioSource.isPlaying) musicManager.SetVolume(volume / 100);
        musicManager.PlayMusic();

        textMeshProUGUI.text = "Sound " + volume + "%";

    }
    protected override void Update()
    {
        base.Update();
        if (selected)
        {
            soundControlObj.SetActive(true);
        }
        else
        {
            soundControlObj.SetActive(false);
        }
        if(!selected) return;
        textMeshProUGUI.text = "Sound " + volume + "%";
        if(Input.GetButtonDown("Gameboy Left"))
        {
            volume = Mathf.Clamp(volume - 5, 0, 100);
            musicManager.SetVolume(volume / 100);
        }
        if (Input.GetButtonDown("Gameboy Right"))
        {
            volume = Mathf.Clamp(volume + 5, 0, 100);
            musicManager.SetVolume(volume / 100);
        }
    }

    public override void Press()
    {

    }
}
