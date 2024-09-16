using UnityEngine;
using TMPro;

public class TextColorable : MonoBehaviour
{
    private TMP_Text _text;
    private void Awake()
    {
        ColorManager.OnColorChanged += HandleColorChange;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.color = new Color(1f, 1f, 1f, 1f);
        _text.faceColor = new Color(0.9921569f, 1f, 0.9882353f, 1f);
    }
    private void HandleColorChange(ColorPalette palette)
    {
        _text.faceColor = palette.color1;

        _text.ForceMeshUpdate();
    }
    private void OnDestroy()
    {
        ColorManager.OnColorChanged -= HandleColorChange;
    }
}
