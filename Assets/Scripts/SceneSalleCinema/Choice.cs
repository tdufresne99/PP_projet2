using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneSalleCinema
{
    public class Choice : MonoBehaviour
    {
        [SerializeField] private MessagesHolder messagesHolder;
        private string _text;
        void Awake()
        {
            // _text = GetComponent<>
        }
        public void OnChoiceClick()
        {
            if(messagesHolder.clickable) messagesHolder.StartAnswerSlide();
        }
    }
}
