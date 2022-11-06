using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance { get; private set; }

    public Sound[] sounds;

    private void Awake() {

        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(this);

        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;

            UpdateSourceVolume(sound);
        }
    }

    private void Start() {

        GameSettingsManager.instance.SoundSettings.OnVolumeSettingsChanged += UpdateAllSources;

        PlaySound("Theme");
    }

    public void PlaySound(string name) {

        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if (sound == null) {
            Debug.LogWarning(String.Format("Sound \"{0}\" could not be found!", name));
            return;
        }

        sound.source.Play();
    }

    private void UpdateAllSources() {

        foreach (Sound sound in sounds) {
            UpdateSourceVolume(sound);
        }
    }

    private void UpdateSourceVolume(Sound sound) {

        if (sound.soundType == SoundTypes.Music)
            sound.source.volume = sound.volume * GameSettingsManager.instance.SoundSettings.Master * GameSettingsManager.instance.SoundSettings.Music;
        else if (sound.soundType == SoundTypes.Effects)
            sound.source.volume = sound.volume * GameSettingsManager.instance.SoundSettings.Master * GameSettingsManager.instance.SoundSettings.Effects;
    }
}

public enum SoundTypes {
    Music,
    Effects
}
