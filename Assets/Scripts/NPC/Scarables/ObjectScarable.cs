using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum PossessableType
{
    puppet = (1 << 0),
    spider = (1 << 1),
    npc = (1 << 2)
}

public class ObjectScarable : Scarable
{
    public PossessableType scarableBy;
}
