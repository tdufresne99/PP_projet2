using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BFHouse
{
    public class Choice : MonoBehaviour
    {
        [SerializeField] private MessagesHolder _messagesHolderCS;
        private Animator _anim;
        void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        public void OnChoiceClick()
        {
            if (_messagesHolderCS.clickable) 
            {
                if(_messagesHolderCS.Index == 0) _messagesHolderCS.ShowAnswer();
                else _messagesHolderCS.StartAnswerSlide();

                Debug.Log("supposed to popOut");
                _anim.SetTrigger("popOut");
                _anim.SetTrigger("popOut");
            }
        }
    }
}
