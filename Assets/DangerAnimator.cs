using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerAnimator : MonoBehaviour
{
    public Animator Animator;

    // Update is called once per frame
    void Update()
    {
        Animator.SetInteger("Danger", LoseCondition.Danger);
    }
}
