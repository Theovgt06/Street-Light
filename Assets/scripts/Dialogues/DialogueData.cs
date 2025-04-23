// Ce script permet de cr�er un �diteur personnalis� pour les DialogueData
// � placer dans un dossier "Editor"
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

// Ajout � faire dans DialogueManager.cs pour sauvegarder automatiquement la couleur :
// Dans void OnChoiceSelected(int index), apr�s ChangeLampColor(choice.lampColor);
// --> DialogueSaveSystem.SaveLampColor(choice.lampColor);
