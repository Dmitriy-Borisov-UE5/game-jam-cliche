using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class DialogueElement {

    public int speakerID;

    [InspectorReadOnly]
    public string speakerName;

    [TextArea]
    public string text;

    public DialogueElement(string speakerName, string text) {
        this.speakerName = speakerName;
        this.text = text;
    }
}
