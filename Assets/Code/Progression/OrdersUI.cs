using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrdersUI : MonoBehaviour
{
    public Image[] images;

    // Update is called once per frame
    void Start()
    {
        var orders = FindObjectOfType<ListOfOrders>();
        orders.OnOrdersChange += Orders_OnOrdersChange;
        Orders_OnOrdersChange(new List<Recepie>());
    }

    private void Orders_OnOrdersChange(List<Recepie> obj)
    {
        for(int i = 0; i < images.Length; i++)
        {
            if (i < obj.Count)
            {
                images[i].gameObject.SetActive(true);
                images[i].sprite = obj[i].product.GetComponent<SpriteRenderer>().sprite;
            }
            else
                images[i].gameObject.SetActive(false);
        }
    }
}
