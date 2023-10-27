using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    // Dialog
    public List<string> DisabledDialogueList = new List<string>();
    public List<string> DisabledEnterSceneList = new List<string>();
    public bool IsDialogueOpened;
    public string CurrentScene = "nouvelle_map";

    // Characters
    public Vector2 BrumePosition;
    public Vector2 ChienPosition;

    // Water
    public float WaterFillAmount = 1;
    // Fire & Music & Water
    [SerializeField]
    private int pathNumber;
    public event Action<int> PathNumberChanged;
    public int PathNumber
    {
        get { return pathNumber; }
        set
        {
            if (pathNumber != value)
            {
                pathNumber = value;
                OnPathNumberChanged();
            }
        }
    }
    protected virtual void OnPathNumberChanged()
    {
        PathNumberChanged?.Invoke(pathNumber);
    }

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
        // BrumePosition = new Vector2(13, 0);
        // ChienPosition = new Vector2(15, -1);
    }
}
