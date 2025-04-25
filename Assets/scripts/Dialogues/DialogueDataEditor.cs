// Ce script permet de créer un éditeur personnalisé pour les DialogueData
// à placer dans un dossier "Editor"
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueData))]
public class DialogueDataEditor : Editor
{
    SerializedProperty dialogueLines;
    SerializedProperty choices;

    void OnEnable()
    {
        dialogueLines = serializedObject.FindProperty("dialogueLines");
        choices = serializedObject.FindProperty("choices");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Dialogue Lines", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(dialogueLines, true);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Dialogue Choices", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(choices, true);

        serializedObject.ApplyModifiedProperties();
    }
}

// Ajout à faire dans DialogueManager.cs pour sauvegarder automatiquement la couleur :
// Dans void OnChoiceSelected(int index), après ChangeLampColor(choice.lampColor);
// --> DialogueSaveSystem.SaveLampColor(choice.lampColor);
