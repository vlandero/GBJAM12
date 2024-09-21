using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScreen : MonoBehaviour
{

    private void Start()
    {
        // GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>().PlayMusic();
    }
    void Update()
    {
        if(Input.GetButtonDown("Gameboy B"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
