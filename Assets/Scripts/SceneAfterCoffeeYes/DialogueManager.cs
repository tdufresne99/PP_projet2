using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AfterCoffeeYes
{
    public class DialogueManager : MonoBehaviour
    {

        [SerializeField] private GameObject _textBox;
        [SerializeField] private GameObject _choiceHolder;
        [SerializeField] private GameObject _fadeOut;
        [SerializeField] private TypeWriterEffect _text;
        [SerializeField] private bool _playerToldTheTruth;

        private string[] _firstDialogue = new string[]
        {
            "Emma : Mon amour, il y a quelque chose que je dois te dire.",
            "Antoine :  Qu'est-ce qu'il y a ? Tu as l'air inquiète.",
        };
        private int _firstDialogueIndex = 0;


        private string[] _dialogueTruth = new string[]
        {
            "Emma : Eh bien, j'ai accepté de sortir avec mon meilleur ami et j'ai décidé de mettre fin à notre relation.",
            "Antoine : Quoi ? Tu es sérieuse ? Tu ne me dis ça que maintenant ? Tu es vraiment égoïste !",
            "Emma : Je suis désolée, je ne voulais pas te blesser. Mais c'était une décision difficile à prendre.",
            "Antoine : Tu ne mérites pas mon amour ni ma compréhension. Je te souhaite simplement de souffrir autant que tu m'as fait souffrir.",
            "Emma : Je comprends ta réaction, mais sache que je t'aime toujours. Cette relation n'a rien à voir avec mes sentiments pour toi.",
            "Antoine : Tu ne peux pas avoir le beurre et l'argent du beurre. Tu es en train de détruire notre amour pour un ami de passage. Tu vas regretter ton choix un jour.",
            "Emma : Je suis désolée que tu penses ainsi. J'espère que tu trouveras bientôt la paix et que tu pourras me pardonner un jour.",
            "Antoine : Je ne sais pas si un jour je pourrais te pardonner. En attendant, je te souhaite tout le malheur du monde.",
        };

        private string[] _dialogueLie = new string[]
        {
            "Emma : Eh bien, mon meilleur ami, il s'est confessé et j'ai refusé. Je me sens un peu mal à l'aise de te le dire, parce que je sais que tu n'aimes pas Chris et que tu m'avais prévenue.",
            "Antoine : Si tu m'avais écouté et que tu n'aurais pas continué à le voir tu n'aurais pas eu à vivre ça, mais je suis heureux que tu m'aies dit la vérité. Tu sais que je déteste les mensonges. ",
            "Emma: Je suis désolée j'aurais dû t'écouter.",
            "Antoine : Je vais aller m'en occuper! Il n'aurait pas dû t'approcher!",
            "Emma: Je te jure que c'est fini, tu n'as pas besoin...",
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
            if (_dialogueIndex > _dialogue.Length - 1)
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
            if(DecisionManager.Instance.ToldTheTruth)
            {
                SceneManager.LoadScene("EndingFriend");
            }
            else
            {
                SceneManager.LoadScene("EndingFight");
            }
        }

        public void AssignPlayerChoice(bool isTruth)
        {
            DecisionManager.Instance.ToldTheTruth = isTruth;
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
