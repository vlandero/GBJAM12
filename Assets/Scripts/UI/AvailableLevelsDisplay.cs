using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvailableLevelsDisplay : MonoBehaviour
{
    ButtonSelector buttonSelector;
    int latestUnlockedLevel = 1;
    LevelManager levelManager;
    MusicManager musicManager;

    public GameObject youWinSprite;
    public GameObject titleSprite;

    private void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
        musicManager.PlayMusic();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        if (levelManager.youWin)
        {
            youWinSprite.SetActive(true);
            titleSprite.SetActive(false);
        }
        else
        {
            titleSprite.SetActive(true);
            youWinSprite.SetActive(false);
        }
        levelManager.currentLevel = 0;
        buttonSelector = GetComponent<ButtonSelector>();
        int i = 1;
        latestUnlockedLevel = levelManager.latestUnlockedLevel;
        for (i = 1; i <= latestUnlockedLevel; i++)
        {
            LevelButton lvButton = buttonSelector.buttons[i - 1].GetComponent<LevelButton>();
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
            levelManager.youWin = false;
            SceneManager.LoadScene(0);
        }
    }
}
