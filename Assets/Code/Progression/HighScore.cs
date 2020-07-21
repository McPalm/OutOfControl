using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HighScore : MonoBehaviour
{
    static public int highscore;

    public UnityEvent<int> OnChangeValue;
    public UnityEvent<int> OnNewHighscore;
    


    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        Debug.Log($"Git hi: {highscore}");
        OnChangeValue.Invoke(highscore);
    }

    public bool Submit(int score)
    {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            OnChangeValue.Invoke(highscore);
            OnNewHighscore.Invoke(highscore);
            return true;
        }
        return false;
    }

    public void FetchScore()
    {
        Submit(Score.Instance.score);
    }
    
}
