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
        private string _firstDialogue = "Antoine : Salut chérie, comment s'est passée ta journée aujourd'hui ? ";

        [SerializeField]
        private string[] _dialogueTruth = new string[]
        {
            "Emma : Salut, ça va. J'ai fait des courses avec mon ami aujourd'hui.",
            "Antoine : Ah bon ? Avec quel ami ?",
            "Emma : Avec Chris.",
            "Antoine : Chris ?! Je t'ai dit que je ne voulais pas que tu le revois et que même si tu devais absolument le voir, je t'ai que je voulais que tu me le dises !",
            "Emma : Je suis désolée, je ne voulais pas te contrarier. Mais je voulais être honnête avec toi et te dire la vérité.",
            "Antoine : Je suis content que tu sois honnête. Mais je ne veux pas que tu le revois.",
            "Emma : Je suis vraiment désolée, promis. J'espère que tu peux me pardonner.",
            "Antoine : Bien sûr, je te pardonne, puisque tu me dis que tu ne vas pas le revoir...",
        };

        [SerializeField]
        private string[] _dialogueLie = new string[]
        {
            "Emma: Salut, ça va. Rien de spécial, j'ai juste fait quelques courses.",
            "Antoine : D'accord, avec qui es-tu allée ?",
            "Emma : Oh, j'y suis allée toute seule.",
            "Antoine : Vraiment ? Tu n'es pas allée avec Chris ?",
            "Emma : Non, pourquoi est-ce que tu dis ça ?",
            "Antoine : Oh, juste une intuition. Mais bon, peu importe. Comment s'est passée ta journée de shopping ?",
            "Emma : C'était bien, j'ai trouvé quelques trucs sympas. Et toi?",
            "Antoine : Rien de spécial, j'étais en train de faire le souper, vient t'installer.",
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
            SceneManager.LoadScene("Coffee");
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
