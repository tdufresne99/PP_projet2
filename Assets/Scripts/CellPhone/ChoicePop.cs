using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePop : MonoBehaviour
{
    public void OnPopOutEnd()
    {
        gameObject.SetActive(false);
    }
}
