using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMixer : MonoBehaviour
{
    public AudioSource Intro;
    public AudioSource Normal;
    public AudioSource Bad;
    public AudioSource Dire;

    public AudioClip LoseJingle;

    void Start()
    {
        Intro.PlayScheduled(AudioSettings.dspTime + 1.0);
        double time = AudioSettings.dspTime + 1.0 + Intro.clip.length;
        Normal.PlayScheduled(time);
        Bad.PlayScheduled(time);
        Dire.PlayScheduled(time);
    }

    // Update is called once per frame
    void Update()
    {
        switch (LoseCondition.Danger)
        {
            case 0:
                Normal.volume = Mathf.Clamp01(Normal.volume + Time.deltaTime);
                Bad.volume = Mathf.Clamp01(Bad.volume - Time.deltaTime);
                Dire.volume = Mathf.Clamp01(Dire.volume - Time.deltaTime);
                break;
            case 1:
                Normal.volume = Mathf.Clamp01(Normal.volume - Time.deltaTime);
                Bad.volume = Mathf.Clamp01(Bad.volume + Time.deltaTime);
                Dire.volume = Mathf.Clamp01(Dire.volume - Time.deltaTime);
                break;
            case 2:
                Normal.volume = Mathf.Clamp01(Normal.volume - Time.deltaTime);
                Bad.volume = Mathf.Clamp01(Bad.volume - Time.deltaTime);
                Dire.volume = Mathf.Clamp01(Dire.volume + Time.deltaTime * 1.5f);
                break;
        }
    }

    public void GameOver()
    {
        Normal.Stop();
        Bad.Stop();
        Dire.Stop();
        Intro.clip = LoseJingle;
        Intro.Play();
    }
}
