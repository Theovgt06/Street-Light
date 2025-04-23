using UnityEngine;

public class DialogueChoice
{
    public string choiceText;
    public DialogueData nextDialogue;
    public LampColor lampColor; // Enum: Blue, Red, Purple
}

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/Create New Dialogue")]
public class DialogueData : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] dialogueLines; // Toutes les lignes du monologue

    public DialogueChoice[] choices; // Si null ou vide => pas de choix, juste lecture
}
