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
        if (Moveable.Speed > 0f)
        {
            float y = Moveable.Direction.y < -Mathf.Abs(Moveable.Direction.x) ? -1 : 0;
            y = Moveable.Direction.y > Mathf.Abs(Moveable.Direction.x) ? 1 : y;
            Animator.SetFloat("Y", y);
        }
    }
}
