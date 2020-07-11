using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incinerator : Counter
{
    public AudioSource SoundEffect;

    public override void Place(Food food)
    {
        Destroy(food.gameObject);
        GetComponent<Animator>().SetTrigger("Burn");
        SoundEffect.Play();
    }
}
