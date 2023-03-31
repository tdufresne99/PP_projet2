using System.Collections;
using System;
using UnityEngine;
using TMPro;

namespace AfterShop
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
            SoundManager.Instance.PlaySoundTrack(SoundManager.Instance.Typing);

            _textField.text = "";
            foreach (char c in _line)
            {
                _textField.text += c;
                yield return new WaitForSecondsRealtime(_typeWriterDelaySpeed);
            }
            IsTyping = false;
            SoundManager.Instance.StopSoundTrack();

        }
        public void ChangeText(string newText)
        {
            IsTyping = false;
            SoundManager.Instance.StopSoundTrack();

            _line = newText;
            StopAllCoroutines();
            StartCoroutine(CoroutineTypeWriter());
        }

        public void StopTextAnim()
        {
            IsTyping = false;
            SoundManager.Instance.StopSoundTrack();

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
