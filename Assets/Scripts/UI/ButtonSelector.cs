using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    [Header("References")]
    public List<MenuButton> buttons = new List<MenuButton>();

    private int buttonIndex = 0;

    public AudioSource buttonSource;

    private AvailableLevelsDisplay availableLevelsDisplay;

    private void Start()
    {
        availableLevelsDisplay = GetComponent<AvailableLevelsDisplay>();
        buttonSource = GetComponent<AudioSource>();
        buttons[buttonIndex].selected = true;
    }

    private void Update()
    {
        if (availableLevelsDisplay && availableLevelsDisplay.musicPlaying) return;
        if(Input.GetButtonDown("Gameboy Down"))
        {
            buttons[buttonIndex].selected = false;
            buttonIndex = (buttonIndex + 1) % buttons.Count;
            buttons[buttonIndex].selected = true;
            buttonSource.Play();
        }

        if (Input.GetButtonDown("Gameboy Up"))
        {
            buttons[buttonIndex].selected = false;
            buttonIndex = (buttonIndex - 1 + buttons.Count) % buttons.Count;
            buttons[buttonIndex].selected = true;
            buttonSource.Play();
        }

        if (Input.GetButtonDown("Gameboy A"))
        {
            buttons[buttonIndex].Press();
        }
    }
}
