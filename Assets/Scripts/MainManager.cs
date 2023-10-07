using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    // Dialog
    public List<string> DisabledDialogueList = new List<string>();
    public List<string> DisabledEnterSceneList = new List<string>();
    public bool IsDialogueOpened;

    // Characters
    public Vector2 BrumePosition;
    public Vector2 ChienPosition;

    // Music

    // Water
    public float WaterBarFillAmount = 1;

    // Fire
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        BrumePosition = new Vector2(13, 0);
        ChienPosition = new Vector2(15, -1);
    }
}
