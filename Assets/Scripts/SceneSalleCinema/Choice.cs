using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneSalleCinema
{
    public class Choice : MonoBehaviour
    {
        [SerializeField] private MessagesHolder _messagesHolderCS;
        private string _text;

        void Awake()
        {

        }

        public void OnChoiceClick()
        {
            if (_messagesHolderCS.clickable) 
            {
                if(_messagesHolderCS.Index == 0) _messagesHolderCS.ShowAnswer();
                else _messagesHolderCS.StartAnswerSlide();

            }
        }
    }
}
