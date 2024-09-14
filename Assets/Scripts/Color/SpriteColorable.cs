using UnityEngine;

public class SpriteColorable : Colorable
{
    private new void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        base.Awake();
    }
}
