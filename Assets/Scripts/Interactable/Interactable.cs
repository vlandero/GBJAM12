using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public PossessableType interactPermissions;
    public virtual void Interact()
    {
        Debug.Log("Base interact");
    }
}
