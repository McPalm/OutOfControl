using UnityEngine;

public class InputToken
{
    public Vector2 Direction { get; private set; }

    public void SetDirection(Vector2 direction)
    {
        Direction = Vector2.ClampMagnitude(direction, 1f);
    }
}
