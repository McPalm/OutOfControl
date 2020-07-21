using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListOfOrders : MonoBehaviour
{
    public Recepie[] potentialOrders;

    public List<Recepie> CurrentOrders { get; private set; }

    public event System.Action<List<Recepie>> OnOrdersChange;

    IEnumerator Start()
    {
        CurrentOrders = new List<Recepie>();
        yield return null;
        for(; ; )
        {
            yield return new WaitForSeconds(5f + (CurrentOrders.Count * .5f));
            PlaceRandomOrder();
        }
    }

    public void PlaceBulkOrder(int count)
    {
        var order = potentialOrders[Random.Range(0, potentialOrders.Length)];
        for (int i = 0; i < count; i++)
            CurrentOrders.Add(order);
        OnOrdersChange?.Invoke(CurrentOrders);
    }

    public Recepie PlaceRandomOrder()
    {
        CurrentOrders.Add(potentialOrders[Random.Range(0, potentialOrders.Length)]);
        OnOrdersChange?.Invoke(CurrentOrders);
        return CurrentOrders[CurrentOrders.Count - 1];
    }

    public bool FulfillsAnOrder(Food food)
    {
        foreach(var order in CurrentOrders)
        {
            if (order.product.Name == food.Name)
            {
                CurrentOrders.Remove(order);
                OnOrdersChange?.Invoke(CurrentOrders);
                return true;
            }
        }
        return false;
    }
}
