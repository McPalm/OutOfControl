using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class UsefulStuffs
{
    static public void SetForward(this Transform transform, float direction)
    {
        transform.rotation = Quaternion.Euler(0f, direction < 0f ? 180f : 0f, 0f);
    }

    static public float GetRotation(this Transform transform)
    {
        return transform.rotation.eulerAngles.y == 0f ? 1f : -1f;
    }
}
