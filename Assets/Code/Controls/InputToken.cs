using UnityEngine;

public class InputToken
{
    public Vector2 Direction { get; private set; }
    public bool Use => Time.realtimeSinceStartup < use;

    float use = 0f;

    public void PressUse() => use = Time.realtimeSinceStartup + .1f;
    public void ConsumeUse() => use = 0f;

    public void SetDirection(Vector2 direction)
    {
        if (direction.sqrMagnitude > .1f)
            Direction = Vector2.ClampMagnitude(direction, 1f);
        else
            Direction = Vector2.zero;
    }
}
