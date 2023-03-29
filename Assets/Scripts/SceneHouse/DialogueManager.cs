using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BFHouse
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private GameObject _fadeOut;
        [SerializeField] private TypeWriterEffect _text;
        [SerializeField] private string[] _dialogue = new string[]
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
        private int _dialogueIndex = 0;

        void Start()
        {
            Invoke("LoadDialogue", 3f);
        }

        void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                if(_text.IsTyping) _text.StopTextAnim();
                else LoadDialogue();
            }
        }

        public void LoadDialogue()
        {
            if(_dialogueIndex > _dialogue.Length - 1)
            {
                _fadeOut.SetActive(true);
                NextScene();
                return;
            }
            var dialogue = _dialogue[_dialogueIndex];
            _text.ChangeText(dialogue);
            _dialogueIndex++;
        }

        private void NextScene()
        {
            SceneManager.LoadScene(4);
        }
    }
}
