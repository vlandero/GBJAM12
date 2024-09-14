using UnityEngine;

public abstract class Colorable : MonoBehaviour
{
    protected Material _material;
    protected virtual void Awake()
    {
        ColorManager.OnColorChanged += HandleColorChange;

        _material.SetColor("_ColorToReplace1", new Color(0.9921569f, 1f, 0.9882353f, 1f));
        _material.SetColor("_ColorToReplace2", new Color(0.7254902f, 0.7254902f, 0.7254902f, 1f));
        _material.SetColor("_ColorToReplace3", new Color(0.4980392f, 0.4980392f, 0.4980392f, 1f));
        _material.SetColor("_ColorToReplace4", new Color(0.2745098f, 0.2745098f, 0.2745098f, 1f));

        _material.SetColor("_ReplacementColor1", new Color(0.0569f, 1f, 0.9882353f, 1f));
        _material.SetColor("_ReplacementColor2", new Color(0.02f, 0.7254902f, 0.7254902f, 1f));
        _material.SetColor("_ReplacementColor3", new Color(0.0392f, 0.4980392f, 0.4980392f, 1f));
        _material.SetColor("_ReplacementColor4", new Color(0.05098f, 0.2745098f, 0.2745098f, 1f));
    }

    private void HandleColorChange(ColorPalette palette)
    {
        _material.SetColor("_ReplacementColor1", palette.color1);
        _material.SetColor("_ReplacementColor2", palette.color2);
        _material.SetColor("_ReplacementColor3", palette.color3);
        _material.SetColor("_ReplacementColor4", palette.color4);
    }

    private void OnDestroy()
    {
        ColorManager.OnColorChanged -= HandleColorChange;
    }
}
