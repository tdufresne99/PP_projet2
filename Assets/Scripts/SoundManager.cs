using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip _musique;
    public AudioClip _walking;
    public AudioClip _notification;
    public AudioClip _startMovie;
    public AudioClip _fight;
    public AudioClip _btnStartGame;
    public AudioClip _btn;
    public AudioClip _typing;

    private static SoundManager _instance;
    public static SoundManager Instance { get => _instance; set => _instance = value; }

    private AudioSource _audioSource;
    void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);

        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null) Debug.LogWarning("no AudioSource found...");
        else
        {
            _audioSource.clip = _musique;
            _audioSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
