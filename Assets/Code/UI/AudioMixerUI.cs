using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerUI : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SfxSlider;

    public AudioMixer AudioMixer;

    void Start()
    {
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);
        SfxSlider.onValueChanged.AddListener(SetSfxVolume);
        float musicVolume = 0f;
        float sfxVolume = 0f;
        AudioMixer.GetFloat("MusicVolume", out musicVolume);
        AudioMixer.GetFloat("SfxVolume", out sfxVolume);
        MusicSlider.value = musicVolume;
        SfxSlider.value = sfxVolume;
    }


    void SetMusicVolume(float volume)
    {
        if (volume <= -50f)
            AudioMixer.SetFloat("MusicVolume", -100f);
        else
            AudioMixer.SetFloat("MusicVolume", volume);

    }

    void SetSfxVolume(float volume)
    {
        if (volume <= -40f)
            AudioMixer.SetFloat("SfxVolume", -100f);
        else
            AudioMixer.SetFloat("SfxVolume", volume);
    }
}
