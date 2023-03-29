using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Cinema
{
    public class Choice : MonoBehaviour
    {
        [SerializeField] private Animator _otherChoiceAnim;
        [SerializeField] private bool _multiChoice = false;
        [SerializeField] private bool truth;
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

                _anim.SetTrigger("popOut");
                
                if(_multiChoice) 
                {
                    _messagesHolderCS.Truth = truth;
                    _otherChoiceAnim.SetTrigger("popOut");
                }
            }
        }
    }
}
