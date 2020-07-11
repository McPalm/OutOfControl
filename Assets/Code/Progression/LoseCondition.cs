using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{

    public GameObject DebtWarning;

    public GameObject GameOverSplash;

    float time = 60f;

    public Slider Slider;

    // Update is called once per frame
    void Update()
    {
        if(Money.Instance.wallet < 0)
        {
            time -= Time.deltaTime;
            DebtWarning.SetActive(true);
            if (time < 0f)
                Lose();
            Slider.value = time;
            MusicMixer.badness = time > 15f ? 1 : 2;
        }
        else
        {
            DebtWarning.SetActive(false);
            if (time < 10f)
                time = 10f;
            Slider.maxValue = time;
            MusicMixer.badness = 0;
        }
    }

    private void Lose()
    {
        enabled = false;
        Debug.Log("You lose, good day sir");
        GameOverSplash.SetActive(true);
        FindObjectOfType<CharacterInput>().enabled = false;
        StartCoroutine(LoseRoutine());
        FindObjectOfType<MusicMixer>().GameOver();

    }

    IEnumerator LoseRoutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
        MusicMixer.badness = 0;
    }
}
