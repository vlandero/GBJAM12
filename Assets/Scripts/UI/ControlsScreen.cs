using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScreen : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Gameboy B"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
