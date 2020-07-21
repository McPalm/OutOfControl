using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI Display;

    public void SetValue(int value)
    {
        Debug.Log($"Updoot: {value}");
        Display.gameObject.SetActive(value > 0);
        Display.text = $"Hi - {value:000,000}";
    }
}
