using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incinerator : Counter
{
    public override void Place(Food food)
    {
        Destroy(food.gameObject);
        GetComponent<Animator>().SetTrigger("Burn");
    }
}
