using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFight : MonoBehaviour
{
    void Start()
    {
        DecisionManager.Instance.EndingFight = true;
    }
}
