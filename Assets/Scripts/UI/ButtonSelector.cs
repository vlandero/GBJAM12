using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelector : MonoBehaviour
{
    [Header("References")]
    public List<MenuButton> buttons = new List<MenuButton>();

    private int buttonIndex = 0;

    private void Start()
    {
        buttons[buttonIndex].selected = true;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Gameboy Down"))
        {
            buttons[buttonIndex].selected = false;
            buttonIndex = (buttonIndex + 1) % buttons.Count;
            buttons[buttonIndex].selected = true;
        }

        if (Input.GetButtonDown("Gameboy Up"))
        {
            buttons[buttonIndex].selected = false;
            buttonIndex = (buttonIndex - 1 + buttons.Count) % buttons.Count;
            buttons[buttonIndex].selected = true;
        }

        if(Input.GetButtonDown("Gameboy A"))
        {
            buttons[buttonIndex].Press();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
