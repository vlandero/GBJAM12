using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public enum TileType
    {
        Floor,
        Wall
    }

    private Text _text;
    private TileType _tileType;

    private Renderer _renderer;
    private int _x;
    private int _y;


    void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _renderer = GetComponent<Renderer>();
    }

    public void Init(int x, int y)
    {
        _x = x;
        _y = y;
        name = "Tile_" + x + "_" + y;
    }
    public string _Text { get => _text.text; set => _text.text = value; }
    public TileType _TileType
    {
        get => _tileType;
        set
        {
            _tileType = value;
        }
    }
    public int _Cost
    {
        get
        {
            switch (_tileType)
            {
                case TileType.Floor:
                    return 1;
                default:
                    return 0;
            }
        }
    }
    public int _X => _x; 
    public int _Y => _y;
}
