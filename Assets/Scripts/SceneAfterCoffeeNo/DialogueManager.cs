using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AfterCoffeeNo
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
            "Antoine : Salut chérie, comment s'est passée ta journée ?",
        };
        private int _firstDialogueIndex = 0;

        private string[] _dialogueTruth = new string[]
        {
            "Emma : Salut mon amour, ça s'est bien passé, mais j'ai quelque chose à te dire. ",
            "Antoine : Oh non, qu'est-ce qui s'est passé ? ",
            "Emma: Pour être honnête avec toi, j'ai passé un moment assez difficile avec mon meilleur ami aujourd'hui. Il m'a avoué qu'il avait des sentiments pour moi, mais j'ai dû lui dire que je ne ressentais pas la même chose.",
            "Antoine : Oh wow, ça doit être difficile pour toi. Mais merci d'avoir été honnête avec moi et de me l'avoir dit. ",
            "Emma : Oui, je n'ai pas voulu te mentir. Je voulais que tu connaisses la vérité, car tu es la personne la plus importante dans ma vie. ",
            "Antoine : Si tu m'avais écouté et que tu n'aurais pas continué à le voir tu n'aurais pas eu à vivre ça, mais je suis heureux que tu m'aies dit la vérité. Tu sais que je déteste les mensonges. ",
            "Emma : Je suis désolée j'aurais dû t'écouter. ",
            "Antoine : Ça va. C'est fini maintenant. ",
        };

        private string[] _dialogueLie = new string[]
        {
            "Emma : Très bien, j'ai passé une super journée ! J'ai rencontré des copines, on a mangé ensemble, on a fait du shopping... Et toi, quoi de neuf ?",
            "Antoine : Je sais que ton meilleur ami s'est confié à toi.",
            "Emma : **surprise** Comment tu le sais ? ",
            "Antoine : Je l'ai croisé ce matin et on a discuté. Il a avoué.",
            "Emma : Ah... J'ai pas voulu t'en parler tout de suite, mais j'ai refusé ses avances.",
            "Antoine : Je peux comprendre que tu ne sois pas intéressée. Mais pourquoi est-ce que tu m'as menti en disant que tu as passé une super journée et qu'en plus je t'avais dit de ne pas le revoir sans me le dire?",
            "Emma : Je voulais juste éviter de parler de ça tout de suite... C'est pour ça que je t'ai raconté d'autres trucs.",
            "Antoine : Je préfère quand tu es honnête avec moi, je ne veux pas être dans une relation où il y a des mensonges.",
            "Emma : Je suis désolée, je comprends que ça puisse te mettre mal à l'aise. Mais s'il te plaît, comprends... Je ne veux pas perdre notre relation à cause de ça.",
            "Antoine : Je ne veux plus te voir, ça sert à quoi d'être avec quelqu'un qui ne t'écoute pas...",
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
                SceneManager.LoadScene("EndingBF");
            }
            else
            {
                SceneManager.LoadScene("EndingAlone");
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
