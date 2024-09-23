using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI textMeshProUGUI;

    [Header("Colors")]
    public Color32 selectedColor;
    public Color32 baseColor;
    [HideInInspector] public bool selected;

    protected virtual void Start()
    {
        textMeshProUGUI.color = baseColor;
    }

    public virtual void Press()
    {
        Debug.Log("Virtual press on button " + name);
    }

    protected virtual void Update()
    {
        if (selected)
        {
            textMeshProUGUI.color = selectedColor;
        }
        else
        {
            textMeshProUGUI.color = baseColor;
        }
    }
}
