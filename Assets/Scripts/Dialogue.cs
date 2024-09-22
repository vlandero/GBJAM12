using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public List<string> Lines = new List<string>();
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.05f;
    private int currentLineIndex = 0;
    private bool isTyping = false;

    public Animator ghostAnimator;

    void Update()
    {
        if (Input.GetButtonDown("Gameboy A"))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = Lines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                if(currentLineIndex == Lines.Count - 1)
                {
                    SceneManager.LoadScene("Level1");
                }
                ghostAnimator.SetTrigger("Turning");
                NextLine();
            }
        }
    }

    private void Start()
    {
        GetComponent<AudioSource>().volume = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>()._audioSource.volume;
        StartDialogue();
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (currentLineIndex < Lines.Count - 1)
        {
            currentLineIndex++;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueText.text = "";
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in Lines[currentLineIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}
