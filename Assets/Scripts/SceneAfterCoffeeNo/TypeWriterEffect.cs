using System.Collections;
using System;
using UnityEngine;
using TMPro;

namespace AfterCoffeeNo
{
    public class TypeWriterEffect : MonoBehaviour
    {
        [SerializeField] private float _typeWriterDelaySpeed = 0.05f;
        private string _line;
        private TextMeshProUGUI _textField;
        public bool IsTyping = false;

        void Awake()
        {
            _textField = GetComponent<TextMeshProUGUI>();
            _textField.text = "";
        }

        private IEnumerator CoroutineTypeWriter()
        {
            IsTyping = true;
            _textField.text = "";
            foreach (char c in _line)
            {
                _textField.text += c;
                yield return new WaitForSecondsRealtime(_typeWriterDelaySpeed);
            }
            IsTyping = false;
        }
        public void ChangeText(string newText)
        {
            IsTyping = false;
            _line = newText;
            StopAllCoroutines();
            StartCoroutine(CoroutineTypeWriter());
        }

        public void StopTextAnim()
        {
            IsTyping = false;
            StopAllCoroutines();
            _textField.text = _line;
        }

        public string Line
        {
            get => _line;
            set
            {
                _line = value;
            }
        }

    }
}
