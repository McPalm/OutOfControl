using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public LayerMask SolidLayers;
    public float radius;

    public float Speed { get; set; }
    public Vector2 Direction { get; set; }

    public void Move(Vector2 delta)
    {
        transform.position += (Vector3)delta;
        var distance = 0f;
        distance = DistanceInDirection(Vector2.down);
        if (distance < radius * 2 && distance > .1f)
            transform.position += new Vector3(0f, Mathf.Min(radius * 2 - distance, .1f));
        distance = DistanceInDirection(Vector2.right);
        if (distance < radius * 2 && distance > .1f)
            transform.position -= new Vector3(Mathf.Min(radius * 2 - distance, .1f), 0f);
        distance = DistanceInDirection(Vector2.up);
        if (distance < radius * 2 && distance > .1f)
            transform.position -= new Vector3(0f, Mathf.Min(radius * 2 - distance, .1f));
        distance = DistanceInDirection(Vector2.left);
        if (distance < radius * 2 && distance > .1f)
            transform.position += new Vector3(Mathf.Min(radius * 2 - distance, .1f), 0f);

        Speed = delta.magnitude * 60f;
        if(delta.sqrMagnitude > 0f)
            Direction = delta;
    }

    public float DistanceInDirection(Vector2 direction)
    {
        var hit = Physics2D.Raycast((Vector2)transform.position - direction * radius, direction, layerMask:SolidLayers, distance: 10f);
        return hit.distance;
    }
}
