
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueLine : MonoBehaviour
{
    public string Speaker { get; set; }
    public string Text { get; set; }
    public List<DialogueLine> dialogues = new List<DialogueLine>();

    // sin tanta saliva que no es mamada a la verrrrrga 

    void Start()
    {

        dialogues.Add(new DialogueLine { Speaker = "Barista", Text = "Hey gorgeous!" });
        dialogues.Add(new DialogueLine { Speaker = "Costumer", Text = "Hii, how are you?" });
        dialogues.Add(new DialogueLine { Speaker = "Barista", Text = "Super good, thank you for asking, ready to order?" });
        dialogues.Add(new DialogueLine { Speaker = "Costumer", Text = "Oh yes!" });
        dialogues.Add(new DialogueLine { Speaker = "Barista", Text = "Perfect,I'm all ears" });
        // live love laugh copy paste wey tlj

        foreach (var dialogue in dialogues)
        {
            Debug.Log($"{dialogue.Speaker}:{dialogue.Text}");
        }

    }

}       

  