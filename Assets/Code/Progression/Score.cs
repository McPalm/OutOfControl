using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    static public Score Instance;

    public int score = 0;
    public TextMeshProUGUI text;

    private void Start()
    {
        Instance = this;
        text.text = $"{score:000,000}";
    }

    public void AddScore(int value)
    {
        score += value;
        text.text = $"{score:000,000}";
    }
    
}
