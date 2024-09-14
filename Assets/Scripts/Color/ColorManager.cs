using System.Collections.Generic;
using UnityEngine;

public static class Delegates
{
    public delegate void OneColorDelegate(ColorPalette palette);
}

public enum ColorNames
{
    ghost,
    npc,
    officer
}
public class ColorManager : MonoBehaviour
{
#region Variables
    public static Delegates.OneColorDelegate OnColorChanged;

    private List<ColorPalette> _palettes =  new List<ColorPalette>();

    private Dictionary<ColorNames, int> _colors = new Dictionary<ColorNames, int>
    {
        { ColorNames.ghost , 0},
        { ColorNames.npc , 1 },
        { ColorNames.officer, 2 }
    };
    #endregion
    public ColorNames _temp;

    private void Awake()
    {
        foreach(ColorNames name in _colors.Keys)
        {
            _palettes.Add(Resources.Load<ColorPalette>(name.ToString()));
        }
    }

    private void Update()
    {
        ColorChange(_temp);
    }
    public void ColorChange(ColorNames colorName)
    {
        OnColorChanged?.Invoke(_palettes[_colors[colorName]]);
    }
}
