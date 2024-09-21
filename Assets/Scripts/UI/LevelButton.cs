using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MenuButton
{
    public int level;
    public bool locked = true;
    public override void Press()
    {
        Debug.Log(level);
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
        base.Update();
    }

}
