using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager instance { get; private set; }

    [SerializeField]
    private GameObject dialogueContainer;

    [SerializeField]
    private TextMeshProUGUI dialogueNameText;

    [SerializeField]
    private TextMeshProUGUI dialogueMessageText;

    [SerializeField]
    private TextMeshProUGUI dialogueCommandText;

    [SerializeField]
    private DialogueSpeedLevels textSpeed = DialogueSpeedLevels.Instant;

    [SerializeField]
    private bool autoAdvance;

    [SerializeField]
    private bool canAutoAdvanceOnLastPhrase;

    private Queue<DialogueElement> dialogueElements = new Queue<DialogueElement>();

    private string currentPhrase;
    private bool isTypingPhrase;

    private void Awake() {

        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start() {

        dialogueContainer.SetActive(false);
    }

    public void StartDialogue(DialogueData dialogueData) {

        dialogueContainer.SetActive(true);

        dialogueElements.Clear();

        foreach(DialogueElement phrase in dialogueData.phrases)
            dialogueElements.Enqueue(phrase);

        NextPhrase();
    }

    public void StopDialogue() {

        dialogueContainer.SetActive(false);
    }

    public void NextPhrase() {

        StopAllCoroutines();

        if (isTypingPhrase)
            CompletePhrase(true);
        else if (dialogueElements.Count > 0)
            DisplayNextPhrase();
        else
            StopDialogue();
    }

    private void DisplayNextPhrase() {

        dialogueCommandText.gameObject.SetActive(false);

        if (dialogueElements.Count > 1)
            dialogueCommandText.text = "Continue";
        else
            dialogueCommandText.text = "END";

        DialogueElement dialogueElement = dialogueElements.Dequeue();

        dialogueNameText.text = dialogueElement.speakerName;

        StartCoroutine(TypePhrase(dialogueElement.text));
    }

    IEnumerator TypePhrase (string phrase) {

        isTypingPhrase = true;
        currentPhrase = phrase;

        if (textSpeed == 0)
            dialogueMessageText.text = currentPhrase;

        else {
            float waitSeconds = 0;

            if (textSpeed == DialogueSpeedLevels.Slow)
                waitSeconds = 0.1f;
            else if (textSpeed == DialogueSpeedLevels.Medium)
                waitSeconds = 0.05f;
            else if (textSpeed == DialogueSpeedLevels.Fast)
                waitSeconds = 0.02f;

            dialogueMessageText.text = "";

            foreach (char character in currentPhrase.ToCharArray()) {

                dialogueMessageText.text += character;
                yield return new WaitForSecondsRealtime(waitSeconds);
            }
        }

        CompletePhrase();
    }

    private void CompletePhrase(bool setTextToCurrentPhrase = false) {

        if (setTextToCurrentPhrase)
            dialogueMessageText.text = currentPhrase;

        isTypingPhrase = false;
        dialogueCommandText.gameObject.SetActive(true);

        if (autoAdvance)
            StartCoroutine(AutoAdvanceToNextPhrase());
    }

    IEnumerator AutoAdvanceToNextPhrase() {

        yield return new WaitForSecondsRealtime(0.5f);

        if (dialogueElements.Count > 0 || canAutoAdvanceOnLastPhrase)
            NextPhrase();
    }
}
