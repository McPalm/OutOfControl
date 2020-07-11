using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObjects : MonoBehaviour, CharacterInput.IControllable
{
    public LayerMask CarryMask;

    public InputToken InputToken { get; set; }
    Moveable Moveable { get;set;}

    Food held;

    // Start is called before the first frame update
    void Start()
    {
        Moveable = GetComponent<Moveable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (InputToken.Use)
        {
            if (held)
            {
                var hit = Physics2D.BoxCast((Vector2)transform.position + Moveable.Direction.normalized, Vector2.one, 0f, Vector2.zero, 0f, CarryMask);
                if(hit)
                {
                    var Counter = hit.transform.GetComponent<Counter>();
                    if(Counter && Counter.IsEmpty)
                    {
                        Counter.Place(held);
                        held = null;
                    }
                    if (Counter)
                    {
                        InputToken.ConsumeUse();
                        return;
                    }
                }
                Drop();
                InputToken.ConsumeUse();
            }
            else
            {
                var hit = Physics2D.BoxCast((Vector2)transform.position + Moveable.Direction.normalized, Vector2.one, 0f, Vector2.zero, 0f, CarryMask);
                if (hit)
                {
                    var carry = hit.transform.GetComponent<Food>();
                    if (carry)
                    {
                        PickUp(carry);
                        InputToken.ConsumeUse();
                        return;
                    }
                    var crate = hit.transform.GetComponent<Crate>();
                    if(crate)
                    {
                        var food = Instantiate(crate.GetFood());
                        PickUp(food);
                        InputToken.ConsumeUse();
                        return;
                    }
                    var counter = hit.transform.GetComponent<Counter>();
                    if(counter && !counter.IsEmpty)
                    {
                        var food = counter.Grab();
                        PickUp(food);
                        InputToken.ConsumeUse();
                        return;
                    }
                }
            }

        }
    }

    public void PickUp(Food obj)
    {
        obj.transform.position = transform.position + Vector3.up;
        obj.transform.SetParent(transform);
        held = obj;
    }

    public void Drop()
    {
        held.transform.position = (Vector2)transform.position + Moveable.Direction.normalized;
        held.transform.SetParent(null);
        held = null;
    }
}
