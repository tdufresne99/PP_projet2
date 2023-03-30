using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coffee
{
    public class DialogueManager : MonoBehaviour
    {

        [SerializeField] private GameObject _textBox;
        [SerializeField] private GameObject _choiceHolder;
        [SerializeField] private GameObject _fadeOut;
        [SerializeField] private TypeWriterEffect _text;
        [SerializeField] private bool _playerChoseYes;

        private string[] _firstDialogue = new string[]
        {
            "Chris : Hey ummmmm j'en profite, j'aimerais te dire quelque chose. ",
            "Emma : Oui c'est quoi ?",
            "Chris : Écoute, il y a quelque chose que je veux te dire depuis un moment maintenant.",
            "Emma : Ah bon ? Qu'est-ce que c'est ?",
            "Chris : Eh bien, voilà, pour être honnête avec toi, je suis amoureux de toi depuis un moment maintenant.",
            "Emma : Oh, mais tu sais que je suis avec Antoine. ",
            "Chris : Je sais et je sais que c'est soudain, mais je ne pouvais plus garder ça pour moi. J'espère que tu ne seras pas trop mal à l'aise.",
        };
        private int _firstDialogueIndex = 0;


        private string[] _dialogueYes = new string[]
        {
            "Emma : Non, je ne le suis pas. En fait, j'apprécie ton honnêteté.",
            "Chris : Vraiment ? C'est super. Je suis vraiment heureux que tu le prennes bien.",
            "Emma: Écoute, je ne sais pas trop quoi dire, mais je pense que tu es une personne vraiment formidable. Et j'aimerais beaucoup sortir avec toi.",
            "Chris: Vraiment ? Tu acceptes ? C'est génial ! Je suis aux anges !",
            "Emma: Oui, je suis d'accord. Je pense que je ne peux pas rester plus longtemps avec lui.",
            "Chris: Merci beaucoup. Tu ne sais pas à quel point cela signifie pour moi. Je suis ravi de sortir avec toi.",
            "Emma: Moi aussi, je suis impatiente de voir ce que l'avenir nous réserve.",
        };

        private string[] _dialogueNo = new string[]
        {
            "Emma : Écoute, je suis flattée que tu éprouves des sentiments pour moi. Mais je suis déjà en couple et je suis heureuse avec mon petit ami.",
            "Chris : Oh, je vois.",
            "Emma: Oui, je suis désolée si cela te déçoit. Mais je ne peux pas sortir avec toi. Je suis déjà engagée dans une relation amoureuse.",
            "Chris: Je comprends. Je suis désolé d'avoir mis cela sur la table et de te mettre dans une situation difficile.",
            "Emma: Ne t'en fais pas. Je suis contente que tu aies été honnête avec moi. Mais je ne veux pas risquer de briser ma relation avec mon petit ami. ",
            "Chris: Je comprends tout à fait. Je ne voulais pas te mettre dans une situation inconfortable. Je voulais juste que tu saches ce que je ressens.",
            "Emma: Je suis contente que tu aies eu le courage de me le dire. Mais pour le moment, je dois rester fidèle à ma relation actuelle.",
            "Chris: Bien sûr, je comprends. Je suis désolé de t'avoir mis dans une situation inconfortable.",
            "Emma: Ne t'en fais pas. Nous sommes toujours amis, et j'apprécie ta sincérité.",
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
                else if(_firstDialogueShown)
                {
                    if (_text.IsTyping) _text.StopTextAnim();
                    else LoadFirstDialogue();
                }
                
            }
        }

        private void FirstDialogue()
        {
            LoadFirstDialogue();
            _firstDialogueShown = true;
        }

        private void DisplayChoice()
        {
            _isChoosing = true;
            _textBox.SetActive(false);
            _choiceHolder.SetActive(true);
        }

        public void LoadFirstDialogue()
        {
            if (_firstDialogueIndex > _firstDialogue.Length - 1)
            {
                DisplayChoice();
                return;
            }
            var dialogue = _firstDialogue[_firstDialogueIndex];
            _text.ChangeText(dialogue);
            _firstDialogueIndex++;
        }
        public void LoadDialogue()
        {
            if (_dialogueIndex > _dialogueYes.Length - 1)
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
            if(DecisionManager.Instance.SaidYesToChris)
            {
                SceneManager.LoadScene(8);
            }
            else
            {
                SceneManager.LoadScene(9);
            }
        }

        public void AssignPlayerChoice(bool isYes)
        {
            _playerChoseYes = isYes;
            _textBox.SetActive(true);
            _choiceHolder.SetActive(false);
            _isChoosing = false;
            _madeTheChoice = true;
            DecisionManager.Instance.SaidYesToChris = isYes;

            if(isYes)
            {
                _dialogue = _dialogueYes;
            }
            else
            {
                _dialogue = _dialogueNo;
            }
            LoadDialogue();
        }
    }
}
