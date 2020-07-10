using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator Animator;

    Moveable Moveable { get; set; }

    private void Start()
    {
        Moveable = GetComponent<Moveable>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("Speed", Moveable.Speed);
    }
}
