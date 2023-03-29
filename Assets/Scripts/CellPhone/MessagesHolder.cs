using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] _answerBoxes;
    [SerializeField] private GameObject[] _questionBoxes;
    public bool clickable = false;
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
    }


    public void MakeClickable()
    {
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
        Debug.Log("Show answer");
        _answerBoxes[_index].SetActive(true);
        _index++;
        Invoke("StartQuestionSlide", 3f);
    }

    private void ShowNextQuestion()
    {
        _questionBoxes[_index].SetActive(true);
        clickable = true;
    }

    public int Index => _index;
}
