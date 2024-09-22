using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightAfterSeconds : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public int secondsToAppear = 25;
    public int secondsToDisplay = 25;

    private bool hasToAppear = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        StartCoroutine(StartCount());
    }

    private IEnumerator StartCount()
    {
        yield return new WaitForSeconds(secondsToAppear);
        hasToAppear = true;
    }

    private void Update()
    {
        if (hasToAppear)
        {
            if (GameManager.Instance.playerController.possessing)
            {
                return;
            }
            hasToAppear = false;
            StartCoroutine(DisplaySprite());
        }
    }

    private IEnumerator DisplaySprite()
    {
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(secondsToDisplay);
        spriteRenderer.enabled = false;
    }
}
