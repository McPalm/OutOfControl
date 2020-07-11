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
            if (r.Match(a, b))
                return r.product;
        }
        return spoiledFood;
    }
}
