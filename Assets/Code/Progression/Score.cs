using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    static public Score Instance;

    public int score = 0;
    public TextMeshProUGUI text;
    int multiplier = 1;
    public void SetMultipler(int value) => multiplier = value;

    public UnityEvent<int> OnScore;

    private void Start()
    {
        Instance = this;
        text.text = $"{score:0,000,000}";
    }

    public void AddScore(int value)
    {
        score += value * multiplier;
        OnScore.Invoke(value * multiplier);
        text.text = $"{score:0,000,000}";
    }
    
}
