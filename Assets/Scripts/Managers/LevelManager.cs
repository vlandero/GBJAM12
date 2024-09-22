using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int latestUnlockedLevel = 1;
    public int currentLevel = 0;
    public int numberOfLevels = 3;

    public bool playedIntroScene = false;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void FinishLevel()
    {
        latestUnlockedLevel = Mathf.Max(Mathf.Clamp(currentLevel + 1, 1, numberOfLevels), latestUnlockedLevel);
    }
}
