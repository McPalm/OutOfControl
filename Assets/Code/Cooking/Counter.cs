using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public Food Held { get; set; }

    public bool IsEmpty => Held == null;
    public Transform CounterTop;

    public void Place(Food food)
    {
        Held = food;
        food.transform.position = CounterTop.position;
        food.transform.SetParent(null);
        food.GetComponent<Collider2D>().enabled = false;
    }

    public Food Grab()
    {
        Held.GetComponent<Collider2D>().enabled = true;
        var tmp = Held;
        Held = null;
        return tmp;
    }
}
