using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour {

    public static GameSettingsManager instance { get; private set; }

    public SoundSettings SoundSettings { get; private set; }

    private void Awake() {

        DontDestroyOnLoad(this);

        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        SoundSettings = new SoundSettings();
        SoundSettings.Initialize(100.0f, 100.0f, 100.0f);
    }
}
