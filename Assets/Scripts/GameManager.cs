using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [HideInInspector] public PlayerController playerController;

    [HideInInspector] public NPC[] npcs;

    public Transform mapExit;

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

    private void Start()
    {
        npcs = FindObjectsOfType<NPC>();
        playerController = FindObjectsOfType<PlayerController>()[0];
    }
}
