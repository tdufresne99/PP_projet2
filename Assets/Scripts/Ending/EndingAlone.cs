using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAlone : MonoBehaviour
{
    void Start()
    {
        DecisionManager.Instance.EndingAlone = true;
    }
}
