using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreMultiplier : MonoBehaviour
{
    float hygene = 0f;
    int spoiledFood;

    int currentMultiplier = 1;
    

    public UnityEvent<float> OnHygeneChanged;
    public UnityEvent<int> OnMultiplerChanged;
    public UnityEvent<string> OnMultiplerChangedFormat;

    void Start()
    {
        OnMultiplerChanged.AddListener((i) =>
        {
            OnMultiplerChangedFormat.Invoke($"Hygiene x{i}");
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (spoiledFood > 0)
            hygene -= Time.deltaTime * spoiledFood * .5f;
        else
            hygene += Time.deltaTime * .2f;
        if (hygene < 0f)
        {
            if(currentMultiplier == 1)
            {
                hygene = 0f;
            }
            else
            {
                Penalty();
                hygene += 5f;
            }
        }
        if (hygene > 5)
        {
            Bonus();
            hygene -= 5f;
        }
        OnHygeneChanged.Invoke(hygene);
    }

    void Penalty()
    {
        if (currentMultiplier > 1)
            currentMultiplier /= 2;
        OnMultiplerChanged.Invoke(currentMultiplier);
    }

    public void SmolBonus(float ammount)
    {
        hygene += ammount;
    }

    void Bonus()
    {
        currentMultiplier++;
        OnMultiplerChanged.Invoke(currentMultiplier);
    }

    public void SetSpoiledFoodCount(int value) => spoiledFood = value;
}
