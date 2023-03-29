using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cinema
{
    public class CellPhone : MonoBehaviour
    {
        [SerializeField] private GameObject _fadeOut;

        public void StartFadeOut()
        {
            _fadeOut.SetActive(true);
            Invoke("ChangeScene", 2.2f);
        }

        private void ChangeScene()
        {
            SceneManager.LoadScene("CinemaPhoneConvo");
        }

    }
}
