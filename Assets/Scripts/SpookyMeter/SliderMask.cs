using UnityEngine;

public class SliderMask : MonoBehaviour
{
    Vector3 _initialPos;
    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.localPosition;
    }
    // Update is called once per frame
    public void MaskSetUp(int rows)
    {
        transform.localPosition = new Vector3(_initialPos.x, 0.06f * rows, _initialPos.z);
    }
}
