using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public PossessableType interactPermissions;
    public GameObject highlight;
    protected virtual void Start()
    {
        highlight.SetActive(false);
    }
    public virtual void Interact()
    {
        Debug.Log("Base interact");
    }
}
