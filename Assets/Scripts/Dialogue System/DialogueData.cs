using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueData {

    private const string DefaultSpeakerName = "-- INVALID --";

    public List<string> speakers = new List<string>();
    public List<string> responses = new List<string>();

    public List<DialogueElement> phrases = new List<DialogueElement>();

    internal void ValidateSpeakerData() {

        foreach(DialogueElement element in phrases) {

            if (element.speakerID >= 0 && element.speakerID < speakers.Count)
                element.speakerName = speakers[element.speakerID];
            else
                element.speakerName = DefaultSpeakerName;
        }
    }
}
