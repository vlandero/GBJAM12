using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MenuButton
{
    protected override void Start()
    {
        base.Start();

    }
    public override void Press()
    {
        SceneManager.LoadScene(1);
    }
}
