using UnityEngine;

public class ResolutionManager: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800, 720, FullScreenMode.Windowed, new RefreshRate() { numerator = 60, denominator = 1});
    }

}
