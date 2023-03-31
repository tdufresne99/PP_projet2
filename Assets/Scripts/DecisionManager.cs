using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    private static DecisionManager _instance;
    public static DecisionManager Instance { get => _instance; set => _instance = value; }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this);
    }

    public bool SaidYesToChris;
    public bool ToldTheTruth;

    public bool EndingAntoine = false;
    public bool EndingChris = false;
    public bool EndingAlone = false;
    public bool EndingFight = false;
}
