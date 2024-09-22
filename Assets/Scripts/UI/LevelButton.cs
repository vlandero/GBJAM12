using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MenuButton
{
    public int level = 0;
    public bool locked = true;
    public GameObject lockedSprite;
    LevelManager levelManager;
    MusicManager musicManager;
    public override void Press()
    {
        levelManager.currentLevel = level;
        levelManager.youWin = false;
        StartCoroutine(PressButton());
        //SceneManager.LoadScene("Level" + level);
    }

    protected override void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        musicManager = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
        textMeshProUGUI.enabled = false;
        lockedSprite.SetActive(true);
    }

    public void Unlock()
    {
        locked = false;
        textMeshProUGUI.enabled = true;
        lockedSprite.SetActive(false);
    }

    protected override void Update()
    {
        if (locked) return;
        base.Update();
    }

    private IEnumerator PressButton()
    {
        musicManager.StopMusic();
        musicManager._audioSource.clip = musicManager._levelSelect;
        musicManager._audioSource.loop = false;
        musicManager.PlayMusic();
        yield return new WaitUntil(() => !musicManager._audioSource.isPlaying);
        musicManager._audioSource.loop = true;
        musicManager._audioSource.clip = musicManager._mainSong;
        if (level == 1 && !levelManager.playedIntroScene)
        {
            levelManager.playedIntroScene = true;
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
        
    }

}
