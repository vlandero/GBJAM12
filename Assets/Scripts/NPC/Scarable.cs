using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scarable : MonoBehaviour
{
    [HideInInspector] public bool canBeScared = false; // variabila pentru a tine evidenta daca am intrat in npc deja, ca sa poata fi speriat ulterior
    [HideInInspector] public NPC npcComponent;
    public int pointsForScaring = 10;

    private void Start()
    {
        npcComponent = GetComponent<NPC>();
    }

    public virtual void Scare() 
    {
        if(canBeScared && !npcComponent.possessed)
        {
            if (npcComponent.isFinalTarget)
            {
                if (SpookyManager.Instance.valueToReachForScaringTarget > SpookyManager.Instance._points) return;

                Debug.Log("YOU WIN!!!");
            }
            StartCoroutine(FinishLevel());
            npcComponent.scared = true;
            npcComponent.highlight.SetActive(false);
            SpookyManager.Instance.AddPoints(pointsForScaring);
            // Debug.Log(name + " was scared!!!");
        }
    }

    private IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>().StopMusic();
        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().FinishLevel();
        SceneManager.LoadScene(1);
    }
}
