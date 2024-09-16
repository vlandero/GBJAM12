using UnityEngine;
using TMPro;
using UnityEditor;

public class TextColorable : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField]
    [Range(1, 4)]
    private int _colorFromPallete;
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
        switch (_colorFromPallete)
        {
            case 1:
                _text.faceColor = palette.color1;
                break;
            case 2:
                _text.faceColor = palette.color1;
                break;
            case 3:
                _text.faceColor = palette.color1;
                break;
            case 4:
                _text.faceColor = palette.color1;
                break;
        }
    }
    private void OnDestroy()
    {
        ColorManager.OnColorChanged -= HandleColorChange;
    }
}
