using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] Food FoodPrefab;

    public Food GetFood()
    {
        Money.Spend(FoodPrefab.value);
        return FoodPrefab;
    }
}
