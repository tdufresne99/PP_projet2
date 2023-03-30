using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Ending
{
    public class MessagesHolder : MonoBehaviour
    {
        [SerializeField] private string[] _lines;
        [SerializeField] private GameObject _fadeIn;
        [SerializeField] private GameObject _fadeOut;
        [SerializeField] private GameObject _singleChoice;
        [SerializeField] private GameObject[] _answerBoxes;
        [SerializeField] private GameObject[] _questionBoxes;
        private bool _truth = true;
        private int _choiceIndex = 0;
        private int _index = 0;
        private float _scrollSpeed = 1000;
        private float _slideDistance = 250f;

        private RectTransform rect;

        void Awake()
        {
            rect = GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);

        }

        void Start()
        {
            ShowNextQuestion();
            _fadeIn.SetActive(true);
        }
        public void MakeClickable()
        {
            if (_index > _questionBoxes.Length - 1) return;
            clickable = true;
        }

        public void StartAnswerSlide()
        {
            clickable = false;
            StartCoroutine(Slide(true));
        }

        public void StartQuestionSlide()
        {
            StartCoroutine(Slide(false));
        }

        private IEnumerator Slide(bool answer)
        {
            var initPos = rect.position.y;
            var endPos = initPos + _slideDistance;
            var newPos = rect.position;

            while (newPos.y < endPos)
            {
                newPos += Vector3.up * _scrollSpeed * Time.deltaTime;
                rect.position = newPos;
                yield return new WaitForFixedUpdate();
            }


            if (answer) ShowAnswer();
            else ShowNextQuestion();
        }

        public void ShowAnswer()
        {
            _answerBoxes[_index].SetActive(true);
            Index++;
            if(_index < _answerBoxes.Length)Invoke("StartQuestionSlide", 3f);
            if (_index > _questionBoxes.Length - 1)
            {
                Invoke("ActivateFadeOut", 3f);
            }
        }

        private void ShowNextQuestion()
        {
            _questionBoxes[_index].SetActive(true);

            var choiceText = _singleChoice.GetComponentInChildren<TextMeshProUGUI>();
            if (choiceText == null) Debug.LogError("choiceText non trouvé");
            else
            {
                if (_index > _lines.Length - 1) return;
                choiceText.text = _lines[_index];
            }

            if (_index <= _questionBoxes.Length - 1)
            {
                Debug.Log("ici");
                clickable = true;
                if(_index > 0)
                {
                    var anim = _singleChoice.GetComponentInChildren<Animator>();
                    anim.SetTrigger("popIn");
                }
            }
        }

        private void ActivateFadeOut()
        {
            _fadeOut.SetActive(true);
            Invoke("NextScene", 2.5f);
        }

        private void NextScene()
        {
            SceneManager.LoadScene("Menu");
        }

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                Debug.Log(_index);
            }
        }
        public bool clickable = false;
    }
}
