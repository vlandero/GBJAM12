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
    spider,
    puppet,
    clown
}
public class ColorManager : MonoBehaviour
{
#region Variables
    public static Delegates.OneColorDelegate OnColorChanged;

    public static ColorManager Instance { get; private set; }

    private List<ColorPalette> _palettes =  new List<ColorPalette>();

    private Dictionary<ColorNames, int> _colors = new Dictionary<ColorNames, int>
    {
        { ColorNames.ghost , 0},
        { ColorNames.npc , 1 },
        { ColorNames.spider, 2 },
        { ColorNames.puppet, 3 },
        { ColorNames.clown, 4 }
    };
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (ColorNames name in _colors.Keys)
        {
            _palettes.Add(Resources.Load<ColorPalette>(name.ToString()));
        }
    }

    private void Start()
    {
        ColorChange(ColorNames.ghost);
    }

    public void ColorChange(ColorNames colorName)
    {
        OnColorChanged?.Invoke(_palettes[_colors[colorName]]);
    }
}
