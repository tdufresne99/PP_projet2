using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shopping
{
    public class DialogueManager : MonoBehaviour
    {

        [SerializeField] private GameObject _textBox;
        [SerializeField] private GameObject _choiceHolder;
        [SerializeField] private GameObject _fadeOut;
        [SerializeField] private TypeWriterEffect _text;
        [SerializeField] private bool _playerChoseTruth;

        private string[] _dialogue = new string[]
        {
            "Chris: Alors, as-tu une idée de ce que tu veux offrir à ton copain pour son anniversaire ?",
            "Emma: Pas vraiment, je ne sais pas quoi acheter.",
            "Chris: Hmm, pourquoi ne pas lui acheter quelque chose qu'il aime ? Peut-être un nouveau jeu vidéo ou un livre sur son sujet préféré.",
            "Emma: Il a déjà tellement de jeux vidéo et je ne suis pas sûre de connaître son sujet préféré.",
            "Chris: Hmm, d'accord. Peut-être que tu pourrais lui acheter quelque chose qu'il peut utiliser tous les jours, comme une nouvelle montre ou un porte-monnaie élégant.",
            "Emma: C'est une bonne idée, mais je ne suis pas sûre de savoir quel style il préfère.",
            "Chris: Je comprends. Et si on allait faire un tour dans une boutique de cadeaux pour hommes ? Ils ont souvent une grande variété de choix et pourraient t'aider à trouver quelque chose qui convient parfaitement à ton copain.",
        };

        private int _dialogueIndex = 0;
        private bool _firstDialogueShown = false;
        void Start()
        {
            Invoke("LoadDialogue", 3f);
        }

        void Update()
        {
            
            if (Input.GetButtonDown("Fire1") && _firstDialogueShown)
            {
                if (_text.IsTyping) _text.StopTextAnim();
                else LoadDialogue();
            }
        }

        public void LoadDialogue()
        {
            if(_firstDialogueShown == false) _firstDialogueShown = true;
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
            SceneManager.LoadScene(6);
        }
    }
}
