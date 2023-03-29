using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentMessage : MonoBehaviour
{
    private TextMeshProUGUI _text;
    void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();

        if(_text == null) Debug.LogWarning("No text found...");
        else Debug.LogWarning(_text);
    }

    public void AsignText(string textValue)
    {
        _text.text = textValue;
    }
    
}
