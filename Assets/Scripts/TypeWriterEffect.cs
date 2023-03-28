using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float _typeWriterDelaySpeed = 0.1f;
    [SerializeField] private string[] _stories;
    private string _story;
    private int _index = 0;
    private TextMeshProUGUI _textField;

    void Awake()
    {
        _textField = GetComponent<TextMeshProUGUI>();
        _story = _stories[_index];
        _textField.text = "";

        StartCoroutine(CoroutineTypeWriter());
    }

    private IEnumerator CoroutineTypeWriter()
    {
        _textField.text = "";
        foreach (char c in _story)
        {
            _textField.text += c;
            yield return new WaitForSecondsRealtime(_typeWriterDelaySpeed); 
        }
    }

    public void ChangeText(int index)
    {
        StopAllCoroutines();
        if(index > _stories.Length) 
        {
            Debug.LogWarning("index trop grand pour tableau length, dernier index a été utilisé");
            index = _stories.Length - 1;
        }
        _story = _stories[index];
        StartCoroutine(CoroutineTypeWriter());
    }
    public void ChangeText()
    {
        StopAllCoroutines();
        _index++;
        if(_index > _stories.Length) _index = 0;
        _story = _stories[_index];
        StartCoroutine(CoroutineTypeWriter());
    }
}
