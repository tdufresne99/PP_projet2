using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedEndings : MonoBehaviour
{
    [SerializeField] private Image _endingAntoine;
    [SerializeField] private Image _endingChris;
    [SerializeField] private Image _endingAlone;
    [SerializeField] private Image _endingFight;

    [SerializeField] private Sprite _spriteEndingAntoine;
    [SerializeField] private Sprite _spriteEndingChris;
    [SerializeField] private Sprite _spriteEndingAlone;
    [SerializeField] private Sprite _spriteEndingFight;
    void Start()
    {
        if (DecisionManager.Instance.EndingAntoine) _endingAntoine.sprite = _spriteEndingAntoine;
        if (DecisionManager.Instance.EndingChris) _endingChris.sprite = _spriteEndingChris;
        if (DecisionManager.Instance.EndingAlone) _endingAlone.sprite = _spriteEndingAlone;
        if (DecisionManager.Instance.EndingFight) _endingFight.sprite = _spriteEndingFight;
    }
}
