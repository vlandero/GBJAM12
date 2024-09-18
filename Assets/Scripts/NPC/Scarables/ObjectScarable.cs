using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PossessableType
{
    puppet,
    spider,
    npc
}

public class ObjectScarable : Scarable
{
    public PossessableType scarableBy;
}
