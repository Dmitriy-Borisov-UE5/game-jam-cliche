using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour {

    public static GameSettingsManager instance { get; private set; }

    [SerializeField]
    private SoundSettings soundSettings;
    public SoundSettings SoundSettings { get { return soundSettings; } }

    private void Awake() {

        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);
    }
}
