using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvailableLevelsDisplay : MonoBehaviour
{
    ButtonSelector buttonSelector;
    int currentLevel = 1;

    private void Start()
    {
        buttonSelector = GetComponent<ButtonSelector>();
        int i = 1;
        // currentLevel = PlayerPrefs.GetInt("currentLevel");
        for (i = 1; i <= currentLevel; i++)
        {
            LevelButton lvButton = buttonSelector.buttons[currentLevel - 1].GetComponent<LevelButton>();
            lvButton.Unlock();
            lvButton.level = i;
        }
        int n = buttonSelector.buttons.Count;
        while (i <= n)
        {
            // Debug.Log("Deleting button with level " + i);
            buttonSelector.buttons.Remove(buttonSelector.buttons[buttonSelector.buttons.Count - 1]);
            i++;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Gameboy B"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
