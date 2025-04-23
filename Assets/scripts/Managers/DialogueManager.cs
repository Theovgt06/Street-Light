using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text dialogueText;
    public GameObject choicesPanel;
    public Button[] choiceButtons; 
    public float typingSpeed = 0.02f;

    [Header("Dialogue Data")]
    public DialogueData startingDialogue;
    private DialogueData currentDialogue;
    private int currentLineIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        StartDialogue(startingDialogue);
    }

    public void StartDialogue(DialogueData dialogue)
    {
        currentDialogue = dialogue;
        currentLineIndex = 0;
        dialogueText.text = "";
        choicesPanel.SetActive(false);
        StartCoroutine(TypeLine(currentDialogue.dialogueLines[currentLineIndex]));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            ContinueDialogue();
        }
    }

    void ContinueDialogue()
    {
        currentLineIndex++;
        if (currentLineIndex < currentDialogue.dialogueLines.Length)
        {
            StartCoroutine(TypeLine(currentDialogue.dialogueLines[currentLineIndex]));
        }
        else
        {
            DisplayChoices();
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char c in line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void DisplayChoices()
    {
        if (currentDialogue.choices == null || currentDialogue.choices.Length == 0)
        {
            // Pas de choix => fin du dialogue
            Debug.Log("Fin du dialogue.");
            return;
        }

        choicesPanel.SetActive(true);

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < currentDialogue.choices.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<TMP_Text>().text = currentDialogue.choices[i].choiceText;
                int choiceIndex = i; // Important : capture pour closure
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(choiceIndex));
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void OnChoiceSelected(int index)
    {
        DialogueChoice choice = currentDialogue.choices[index];

        // Ex : Changer couleur de lampe
        ChangeLampColor(choice.lampColor);

        // Démarrer le dialogue suivant
        if (choice.nextDialogue != null)
        {
            StartDialogue(choice.nextDialogue);
        }
        else
        {
            Debug.Log("Pas de dialogue suivant.");
        }
    }

    void ChangeLampColor(LampColor color)
    {
        // Remplace ceci par ton propre gestionnaire de lumière
        Debug.Log("Changer la lumière en : " + color.ToString());
        // Ex: LampLight.SetColor(blue/red/purple) via une fonction dédiée
    }
}