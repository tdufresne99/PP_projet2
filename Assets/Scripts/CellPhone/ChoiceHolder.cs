using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceHolder : MonoBehaviour
{
    private int _index = 0;
    [SerializeField] private TextMeshProUGUI _choix1;
    [SerializeField] private TextMeshProUGUI _choix2;

    private string[] questions = new string[]
    {
        "Salut chérie, où es-tu en ce moment ?",
        "Le copain : Ah cool, avec qui es-tu ?",
    };
    private string[] answers = new string[]
    {
        "Salut ! Je suis au cinéma, je vais voir le nouveau film de super-héros.",
    };
    private string[] answersTruth = new string[]
    {
        "Euh, avec un ami.",
        "Je suis désolée, pour être honnête avec toi, je ne voulais pas te causer de problèmes. Mais il n'y a rien entre nous, c'est juste un ami.",
        "D'accord, je comprends. Je te promets que je te préviendrai à l'avance la prochaine fois."
    };
    private string[] answersLie = new string[]
    {
        "Juste avec des amis, tu ne les connais pas.",
        "Oui, il est super ! Mais je ne peux pas trop parler, c'est déjà commencé.",
        "Merci, à plus tard !"
    };
    private string[] questionsTruth = new string[]
    {
        "C'est bon, j'ai compris, Tu es avec Chris. Mais tu devrais me prévenir à l'avance que tu allais le voir. Je ne suis pas très à l'aise avec toi en sa compagnie.",
        "Mais j'aimerais quand même être au courant à l'avance.",
        "On se parle plus tard."
    };
    private string[] questionsLie = new string[]
    {
        "D'accord. Comment ça se passe, le film est bien ?",
        "D'accord, pas de soucis. Amuse-toi bien !",
        "À plus tard !"
    };
    
    void Start()
    {

    }

    public void ToggleChoicesNumbers()
    {

    }
}
