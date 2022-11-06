using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings {

    public float Master;
    public float Music;
    public float Effects;

    public void Initialize(float master, float music, float effects) {
        Master = ClampValue(master);
        Music = ClampValue(music);
        Effects = ClampValue(effects);
    }

    public void SetSoundValue(SoundSettingsTypes soundType, float value) {

        if (soundType == SoundSettingsTypes.Master)
            Master = ClampValue(value);
        else if (soundType == SoundSettingsTypes.Music)
            Music = ClampValue(value);
        else if (soundType == SoundSettingsTypes.Effects)
            Effects = ClampValue(value);
    }

    private float ClampValue(float value) {
        return Mathf.Clamp(value, 0.0f, 100.0f);
    }
}
