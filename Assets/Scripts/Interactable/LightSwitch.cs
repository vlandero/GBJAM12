using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] private GameObject affectedLightArea;

    private void Start()
    {
        affectedLightArea.SetActive(false);
    }

    public override void Interact()
    {
        affectedLightArea.SetActive(true);
        StartCoroutine(SwitchOn());
    }

    private IEnumerator SwitchOn()
    {
        yield return new WaitForSeconds(2f);
        affectedLightArea.SetActive(false);
    }
}
