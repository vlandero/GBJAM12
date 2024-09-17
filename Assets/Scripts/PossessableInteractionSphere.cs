using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessableInteractionSphere : MonoBehaviour
{
    [HideInInspector] public Possessable possessable;

    protected virtual void Start()
    {
        possessable = GetComponentInParent<Possessable>();
    }

}
