using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new Recepie", menuName ="Recepie", order = 0)]
public class Recepie : ScriptableObject
{
    public Food ingredient1;
    public Food ingredient2;
    public Food product;
         

    public bool Match(Food a, Food b)
    {
        if (a.Name == ingredient1.Name && b.Name == ingredient2.Name)
            return true;
        return b.Name == ingredient1.Name && a.Name == ingredient2.Name;
    }
}
