using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{

    public GameObject DebtWarning;

    public TextMeshProUGUI CountDown;

    float time = 60f;
    

    // Update is called once per frame
    void Update()
    {
        if(Money.Instance.wallet < 0)
        {
            time -= Time.deltaTime;
            CountDown.text = $"{time:0}";
            DebtWarning.SetActive(true);
            if (time < 0f)
                Lose();
        }
        else
        {
            DebtWarning.SetActive(false);
            if (time < 10f)
                time = 10f;
        }
    }

    private void Lose()
    {
        enabled = false;
        Debug.Log("You lose, good day sir");
        CountDown.text = "You lose, good day sir";
        StartCoroutine(LoseRoutine());
    }

    IEnumerator LoseRoutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
