using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    private float _animSpeed = 0.05f;
    private float _finalScaleMultiplier = 1.5f;

    private float _scaleInit;
    private float _scaleFinal;
    void Awake()
    {
        _scaleInit = transform.localScale.x;

        _scaleFinal = _scaleInit * _finalScaleMultiplier;

        Debug.Log(_scaleInit);
    }
    void OnMouseEnter()
    {
        StopAllCoroutines();
        StartCoroutine(CoroutineAnimHoverEnter());
    }
    void OnMouseExit()
    {
        StopAllCoroutines();
        StartCoroutine(CoroutineAnimHoverExit());
    }

    private IEnumerator CoroutineAnimHoverEnter()
    {
        gameObject.transform.localScale = Vector3.one * _scaleInit;

        while(transform.localScale.x < _scaleFinal)
        {
            gameObject.transform.localScale += Vector3.one * _animSpeed;
            yield return new WaitForFixedUpdate();
        }

        gameObject.transform.localScale = Vector3.one * _scaleFinal;
    }

    private IEnumerator CoroutineAnimHoverExit()
    {
        gameObject.transform.localScale = Vector3.one * _scaleFinal;

        while(transform.localScale.x > _scaleInit)
        {
            gameObject.transform.localScale -= Vector3.one * _animSpeed;
            yield return new WaitForFixedUpdate();
        }

        gameObject.transform.localScale = Vector3.one * _scaleInit;
    }
}
