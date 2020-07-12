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

    IEnumerator Start()
    {
#if UNITY_WEBGL
        yield return new WaitForSecondsRealtime(1f);
        Intro.Play();
        yield return new WaitForSecondsRealtime(Intro.clip.length);
        Normal.Play();
        Bad.Play();
        Dire.Play();
#else
        Intro.PlayScheduled(AudioSettings.dspTime + 1.0);
        double time = AudioSettings.dspTime + 1.0 + Intro.clip.length;
        Normal.PlayScheduled(time);
        Bad.PlayScheduled(time);
        Dire.PlayScheduled(time);
        yield return null;
#endif
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
