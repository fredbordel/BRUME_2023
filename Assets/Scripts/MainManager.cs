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
    public bool is3DVideoDialogueFinished;

    // Characters
    public Vector2 BrumePosition;
    public Vector2 ChienPosition;

    // Water
    public float WaterFillAmount = 1;

    // Fire & Music & Water
    [SerializeField]
    private int pathNumber;
    private int numOfFireOut = 0;
    public event Action<int> NumOfFireOutChanged;
    public int NumOfFireOut
    {
        get { return numOfFireOut; }
        set
        {
            if (numOfFireOut != value)
            {
                numOfFireOut = value;
                OnNumOfFireOutChanged();
            }
        }
    }
    protected virtual void OnNumOfFireOutChanged()
    {
        NumOfFireOutChanged?.Invoke(numOfFireOut);
    }
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
        BrumePosition = new Vector2(13, 0);
        ChienPosition = new Vector2(10, -1);
    }

    public static void DestroyInstance()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
    }
}
