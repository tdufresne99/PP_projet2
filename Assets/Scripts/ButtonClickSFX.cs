using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSFX : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public void PlayButtonClick()
    {
        SoundManager.Instance.PlaySFX(_clip);
    }
}
