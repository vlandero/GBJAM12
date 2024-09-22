using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MenuButton
{
    public int level = 0;
    public bool locked = true;
    public override void Press()
    {
        LevelManager levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        MusicManager musicManager = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
        if (level == 1 && !levelManager.playedIntroScene)
        {
            levelManager.playedIntroScene = true;
            levelManager.currentLevel = 1;
            musicManager.StopMusic();
            SceneManager.LoadScene(3);
            return;
        }
        levelManager.currentLevel = level;
        musicManager.StopMusic();
        SceneManager.LoadScene("Level" + level);
    }

    protected override void Start()
    {
        textMeshProUGUI.enabled = false;
        // add lock on UI
    }

    public void Unlock()
    {
        locked = false;
        textMeshProUGUI.enabled = true;
        // remove lock from UI
    }

    protected override void Update()
    {
        if (locked) return;
        // Debug.Log(level);
        base.Update();
    }

}
