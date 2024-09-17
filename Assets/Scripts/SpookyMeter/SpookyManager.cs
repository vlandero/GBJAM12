using System.Collections;
using UnityEngine;

public class SpookyManager : MonoBehaviour
{
    public static SpookyManager Instance { get; private set; }

    [SerializeField]
    private SliderMask _slider;

    //range intre 0 si 480
    [SerializeField]
    private int _points;

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
    }

    public void AddPoints(int number)
    {
        _points += number;
        _points = Mathf.Clamp(_points, 0, 480);
        _slider.MaskSetUp(_points/10);
    }

    private void Start()
    {
        StartCoroutine(DecreasePoints());
    }

    private IEnumerator DecreasePoints()
    {
        while (true)
        {
            AddPoints(-1);
            yield return new WaitForSeconds(10f);
            yield return new WaitUntil(() => PauseManager.Instance.isPaused == false);
            if (_points == 480)
                break;
        }
    }
}
