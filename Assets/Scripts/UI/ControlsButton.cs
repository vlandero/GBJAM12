using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsButton : MenuButton
{
    public override void Press()
    {
        SceneManager.LoadScene(2);
    }
}
