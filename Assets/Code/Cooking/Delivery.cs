using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : Counter
{
    public ListOfOrders ListOfOrders;
    public AudioSource AudioSource;

    public override void Place(Food food)
    {
        if(ListOfOrders.FulfillsAnOrder(food))
        {
            Destroy(food.gameObject);
            Money.Earn(food.value);
            Score.Instance.AddScore(food.value);
            AudioSource.Play();
        }
        else
        {
            base.Place(food);
        }
    }
}
