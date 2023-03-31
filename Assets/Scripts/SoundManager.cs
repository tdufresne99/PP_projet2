using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip Musique;
    public AudioClip Walking;
    public AudioClip Notification;
    public AudioClip StartMovie;
    public AudioClip Fight;
    public AudioClip BtnStartGame;
    public AudioClip Btn;
    public AudioClip Typing;
    public AudioClip MsgSent;

    private static SoundManager _instance;
    public static SoundManager Instance { get => _instance; set => _instance = value; }

    [SerializeField] private AudioSource _audioSource;
    void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject); 
        if (_audioSource == null) Debug.LogWarning("no AudioSource found...");
        else
        {
            _audioSource.clip = Musique;
            _audioSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    public void PlaySoundTrack(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.loop = true;
        _audioSource.Play();
    }
    public void StopSoundTrack()
    {
        _audioSource.Stop();
    }
}
