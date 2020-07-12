using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour
{
    public float walkSpeed;
    public float thinktime;

    public Moveable Moveable;
    public Chef Chef { get; set; }

    public Crate[] FoodSources;
    public Counter[] CounterTops;

    Crate RandomCrate() => FoodSources[Random.Range(0, FoodSources.Length)];
    Counter RandomCounter() => CounterTops[Random.Range(0, CounterTops.Length)];

    public Food Held;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AIRoutine());
        Chef = GetComponent<Chef>();
    }

    public Recepie RequestedMeal;

    public IEnumerator AIRoutine()
    {
        Crate LastCrate = null;
        for(; ; )
        {
            yield return new WaitForSeconds(thinktime);
            var crate = RandomCrate();
            for (int i = 0; i < 10 && crate == LastCrate; i++)
                crate = RandomCrate();
            LastCrate = crate;
            yield return WalkTo(crate.transform.position, .75f);
            yield return new WaitForSeconds(.5f);
            GrabFrom(crate);
            yield return new WaitForSeconds(thinktime);
            var counter = RandomCounter();
            if(RequestedMeal != null)
            {
                for(int i = 0; i < 10; i++)
                {
                    if (counter.Held != null && RequestedMeal.Match(Held, counter.Held))
                        break;
                    counter = RandomCounter();
                }
                    
            }
            yield return WalkTo(counter.transform.position, .75f);
            yield return new WaitForSeconds(.5f);
            Place(counter);
        }
    }

    private void Place(Counter counter)
    {
        if (counter.IsEmpty)
            counter.Place(Held);
        else
        {
            var dish = Chef.DetermineResult(counter.Held, Held);
            Destroy(Held.gameObject);
            Destroy(counter.Held.gameObject);
            counter.Place(Instantiate(dish));
        }
        Held = null;
    }

    private void GrabFrom(Crate crate)
    {
        Held = Instantiate(crate.GetFood());
        Held.transform.SetParent(transform);
        Held.transform.localPosition = Vector3.up;
        Held.GetComponent<BoxCollider2D>().enabled = false;
    }

    public IEnumerator WalkTo(Vector2 position, float distance)
    {
        var direction = (position - (Vector2)transform.position).normalized;
        if (direction.x != 0)
            transform.SetForward(direction.x);
        while(Vector2.SqrMagnitude((Vector2)transform.position - position) > distance * distance)
        {
            yield return new WaitForFixedUpdate();
            direction = (position - (Vector2)transform.position).normalized;
            Moveable.Move((direction * walkSpeed * Time.fixedDeltaTime));
        }

    }

    
}
