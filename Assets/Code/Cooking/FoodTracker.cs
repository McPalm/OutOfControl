using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodTracker : MonoBehaviour
{
    static public FoodTracker Instance;

    public UnityEvent<int> OnSpoiledFoodChanged;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    int spoiledFood = 0;

    HashSet<Food> AllFood = new HashSet<Food>();

    public void AddFood(Food f) => AllFood.Add(f);
    public void RemoveFood(Food f) => AllFood.Remove(f);

    private void Update()
    {
        int spoiledFood = 0;
        foreach(var food in AllFood)
        {
            if (food.spoiled)
                spoiledFood++;
        }
        if(spoiledFood != this.spoiledFood)
        {
            this.spoiledFood = spoiledFood;
            OnSpoiledFoodChanged.Invoke(spoiledFood);
        }
    }
}
