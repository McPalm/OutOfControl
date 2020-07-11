using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : Counter
{
    public override void Place(Food food)
    {
        Destroy(food.gameObject);
        Money.Earn(food.value);
    }
}
