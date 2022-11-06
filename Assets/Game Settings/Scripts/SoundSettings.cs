using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SoundSettings {

    [Range(0.0f, 1.0f)]
    public float Master = 1.0f;

    [Range(0.0f, 1.0f)]
    public float Music = 1.0f;

    [Range(0.0f, 1.0f)]
    public float Effects = 1.0f;

    public event Action OnVolumeSettingsChanged;

    public void Initialize(float master, float music, float effects) {
        Master = ClampValue(master);
        Music = ClampValue(music);
        Effects = ClampValue(effects);

        OnVolumeSettingsChanged?.Invoke();
    }

    public void SetSoundValue(SoundSettingsTypes soundType, float value) {

        if (soundType == SoundSettingsTypes.Master)
            Master = ClampValue(value);
        else if (soundType == SoundSettingsTypes.Music)
            Music = ClampValue(value);
        else if (soundType == SoundSettingsTypes.Effects)
            Effects = ClampValue(value);

        OnVolumeSettingsChanged?.Invoke();
    }

    private float ClampValue(float value) {
        return Mathf.Clamp(value, 0.0f, 1.0f);
    }
}
