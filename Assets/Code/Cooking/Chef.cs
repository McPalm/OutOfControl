using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    public Recepie[] Recepies;
    public Food spoiledFood;

    public Food DetermineResult(Food a, Food b)
    {
        foreach(var r in Recepies)
        {
            if (r.ingredient1.Name == a.Name && r.ingredient2.Name == b.Name)
                return r.product;
            if (r.ingredient1.Name == b.Name && r.ingredient2.Name == a.Name)
                return r.product;
        }
        return spoiledFood;
    }
}
