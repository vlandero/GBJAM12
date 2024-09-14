using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Delegates
{
    public delegate void OneColorDelegate(Color color);
}
public class ColorManager : MonoBehaviour
{
#region Variables
    public static Delegates.OneColorDelegate OnColorChanged;

    public static Dictionary<string, Color> _colors = new Dictionary<string, Color>
    {
        { "ghost" , Color.white },
        { "npc" , Color.blue }
    };
#endregion
    
    public void ColorChange(string _character)
    {
        _character = _character.ToLower();

        OnColorChanged?.Invoke(_colors[_character]);
    }
}
