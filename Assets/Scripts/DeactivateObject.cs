using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
