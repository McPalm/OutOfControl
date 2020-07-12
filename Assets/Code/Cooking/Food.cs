using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string Name;
    public int value;
    public bool spoiled;

    public bool onGround = false;

    public Food SpoiledFood;

    float health = 5f;

    void Update()
    {
        if (spoiled)
            return;
        if (onGround)
            health -= Time.deltaTime;
        else
            health -= Time.deltaTime / 15f;
        if (health < 0f)
            Spoil();
    }


    void Spoil()
    {
        Name = SpoiledFood.Name;
        value = SpoiledFood.value;
        GetComponent<SpriteRenderer>().sprite = SpoiledFood.GetComponent<SpriteRenderer>().sprite;
        spoiled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
