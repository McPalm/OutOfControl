using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    static public Money Instance;

    public int wallet = 1000;

    public TextMeshProUGUI text;
    
    void Start()
    {
        Instance = this;
    }

    static public void Spend(int value)
    {
        Instance.wallet -= value;
        Instance.text.text = $"${Instance.wallet}";
    }

    static public void Earn(int value)
    {
        Instance.wallet += value;
        Instance.text.text = $"${Instance.wallet}";
    }
}
