using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public List<PossessableType> interactPermissions = new List<PossessableType>();
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
