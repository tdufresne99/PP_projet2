using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentMessage : MonoBehaviour
{
    [SerializeField] private string _truthText;
    [SerializeField] private string _lieText;
    private MessagesHolder _messageHolderCS;
    private TextMeshProUGUI _text;
    void Awake()
    {
        _messageHolderCS = GetComponentInParent<MessagesHolder>();
        _text = GetComponentInChildren<TextMeshProUGUI>();

        if(_text == null) Debug.LogWarning("No text found...");
        AsignText();
    }

    private void AsignText()
    {
        if(_messageHolderCS.Truth)_text.text = _truthText;
        else _text.text = _lieText;
    }
}
