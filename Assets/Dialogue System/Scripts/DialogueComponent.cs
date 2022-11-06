using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueComponent : MonoBehaviour {

    public DialogueData dialogueData;

    public void StartDialogue() {

        DialogueManager.instance.StartDialogue(dialogueData);
    }

    private void OnValidate() {

        dialogueData.ValidateSpeakerData();
    }
}
