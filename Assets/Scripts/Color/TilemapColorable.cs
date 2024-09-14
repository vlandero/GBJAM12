using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapColorable : Colorable
{
    private new void Awake()
    {
        _material = GetComponent<TilemapRenderer>().material;
        base.Awake();
    }
}
