using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AfterShop
{
    public class DialogueManager : MonoBehaviour
    {

        [SerializeField] private GameObject _textBox;
        [SerializeField] private GameObject _choiceHolder;
        [SerializeField] private GameObject _fadeOut;
        [SerializeField] private TypeWriterEffect _text;
        [SerializeField] private bool _playerChoseTruth;
        private string _firstDialogue = "Copain: Salut chérie, comment s'est passée ta journée aujourd'hui ? ";

        [SerializeField]
        private string[] _dialogueTruth = new string[]
        {
            "Copain: Salut chérie, comment s'est passée ta journée aujourd'hui ? ",
            "Antoine : Non, rien de particulier. Je voulais juste te parler d'un truc.",
            "Emma: Ok, de quoi s'agit-il ?",
            "Antoine : Pour être bien honnête avec toi, ton ami, Chris. Je sais qu'il est important pour toi, mais je ne me sens pas à l'aise quand tu passes du temps avec lui.",
            "Emma: Pourquoi pas ? Chris est un ami depuis longtemps.",
            "Antoine : Je ne veux juste pas que tu sois avec lui, il y a quelque chose dans sa façon d'agir qui me dérange. Je n'ai pas confiance en lui.",
            "Emma: C'est injuste, tu ne le connais pas vraiment, tu ne l'as jamais donné une chance.",
            "Antoine : Tu ne sais pas ce que je vois., je veux te protéger. Je ne veux pas que tu sois influencée négativement par quelqu'un qui ne me semble pas fiable.",
            "Emma: Tu sais, Chris n'a rien fait de mal. Il m'écoute, me soutient, me rend heureuse. Il est plus qu'un ami, il est comme un frère pour moi.",
            "Antoine : Je voudrais que tu me dises quand tu es avec lui et que tu évites de le voir le plus possible. Je ne veux pas que tu sois blessée, tu es trop importante pour moi.",
            "Emma: D'accord.",
        };

        [SerializeField]
        private string[] _dialogueLie = new string[]
        {
            "Emma: Chéri, qu'est-ce qui ne va pas ? Tu as l'air soucieux.",
            "Antoine : Non, rien de particulier. Je voulais juste te parler d'un truc.",
            "Emma: Ok, de quoi s'agit-il ?",
            "Antoine : Pour être bien honnête avec toi, ton ami, Chris. Je sais qu'il est important pour toi, mais je ne me sens pas à l'aise quand tu passes du temps avec lui.",
            "Emma: Pourquoi pas ? Chris est un ami depuis longtemps.",
            "Antoine : Je ne veux juste pas que tu sois avec lui, il y a quelque chose dans sa façon d'agir qui me dérange. Je n'ai pas confiance en lui.",
            "Emma: C'est injuste, tu ne le connais pas vraiment, tu ne l'as jamais donné une chance.",
            "Antoine : Tu ne sais pas ce que je vois., je veux te protéger. Je ne veux pas que tu sois influencée négativement par quelqu'un qui ne me semble pas fiable.",
            "Emma: Tu sais, Chris n'a rien fait de mal. Il m'écoute, me soutient, me rend heureuse. Il est plus qu'un ami, il est comme un frère pour moi.",
            "Antoine : Je voudrais que tu me dises quand tu es avec lui et que tu évites de le voir le plus possible. Je ne veux pas que tu sois blessée, tu es trop importante pour moi.",
            "Emma: D'accord.",
        };

        private string[] _dialogue;
        private int _dialogueIndex = 0;
        private bool _isChoosing = false;
        private bool _madeTheChoice = false;
        private bool _firstDialogueShown = false;
        void Start()
        {
            Invoke("FirstDialogue", 3f);
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (_madeTheChoice)
                {
                    if (_text.IsTyping) _text.StopTextAnim();
                    else LoadDialogue();
                }
                else if (_isChoosing)
                {
                    return;
                }
                else
                {
                    if (!_firstDialogueShown) return;
                    if (_text.IsTyping) _text.StopTextAnim();
                    else DisplayChoice();
                }

            }
        }

        private void FirstDialogue()
        {
            _text.ChangeText(_firstDialogue);
            _firstDialogueShown = true;
        }

        private void DisplayChoice()
        {
            _isChoosing = true;
            _textBox.SetActive(false);
            _choiceHolder.SetActive(true);
        }

        public void LoadDialogue()
        {
            if (_dialogueIndex > _dialogueTruth.Length - 1)
            {
                _fadeOut.SetActive(true);
                Invoke("NextScene", 2.2f);
                return;
            }
            var dialogue = _dialogue[_dialogueIndex];
            _text.ChangeText(dialogue);
            _dialogueIndex++;
        }

        public void NextScene()
        {
            SceneManager.LoadScene(4);
        }

        public void AssignPlayerChoice(bool isTruth)
        {
            _playerChoseTruth = isTruth;
            _textBox.SetActive(true);
            _choiceHolder.SetActive(false);
            _isChoosing = false;
            _madeTheChoice = true;

            if(isTruth)
            {
                _dialogue = _dialogueTruth;
            }
            else
            {
                _dialogue = _dialogueLie;
            }
            LoadDialogue();
        }
    }
}
