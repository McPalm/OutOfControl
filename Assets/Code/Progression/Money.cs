using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Money : MonoBehaviour
{
    static public Money Instance;

    public int wallet = 1000;

    public TextMeshProUGUI text;
    public Color PositiveColour;
    public Color DebtColour;

    Color GetColor() => wallet < 0 ? DebtColour : PositiveColour;

    void Start()
    {
        Instance = this;
        Refresh();
    }


    static public void Spend(int value)
    {
        Instance.wallet -= value;
        Instance.Refresh();
            
    }

    private void Refresh()
    {
        text.text = $"${wallet}";
        text.color = GetColor();
    }

    static public void Earn(int value)
    {
        Instance.wallet += value;
        Instance.Refresh();
    }
}
