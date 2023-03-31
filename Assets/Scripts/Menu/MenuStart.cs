using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    [SerializeField] private GameObject _fadeOut;

    void Start()
    {
        
    }

    public void StartGame()
    {
        _fadeOut.SetActive(true);
        Invoke("NextScene", 2.2f);
    }

    private void NextScene()
    {
        SceneManager.LoadScene("CinemaOutside");
    }

    
}
