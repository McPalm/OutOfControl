using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreMultiplier : MonoBehaviour
{
    float hygene = 0f;
    int spoiledFood;

    int currentMultiplier = 1;

    float lossMultiplier = .5f;

    public UnityEvent<float> OnHygeneChanged;
    public UnityEvent<int> OnMultiplerChanged;
    public UnityEvent<string> OnMultiplerChangedFormat;

    void Start()
    {
        OnMultiplerChanged.AddListener((i) =>
        {
            OnMultiplerChangedFormat.Invoke($"Hygiene x{i}");
        });
        FindObjectOfType<ProgressiveDifficulty>().OnStageChange.AddListener(OnStageChange);
    }

    // Update is called once per frame
    void Update()
    {
        if (spoiledFood > 0)
            hygene -= Time.deltaTime * spoiledFood * lossMultiplier;
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
        if (currentMultiplier % 2 == 0)
            hygene += 2.5f;
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

    void OnStageChange(int stage)
    {
        if (stage == 7)
            lossMultiplier = .4f;
        if (stage == 12)
            lossMultiplier = .3f;
        if (stage == 14)
            lossMultiplier = .25f;
    }
    

    public void SetSpoiledFoodCount(int value) => spoiledFood = value;
}
