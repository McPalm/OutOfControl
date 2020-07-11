using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour
{
    public float speed;
    public float thinktime;

    public Crate[] FoodSources;
    public Counter[] CounterTops;

    Crate RandomCrate() => FoodSources[Random.Range(0, FoodSources.Length)];
    Counter RandomCounter() => CounterTops[Random.Range(0, CounterTops.Length)];

    public Food Held;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AIRoutine());
    }

    public IEnumerator AIRoutine()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(thinktime);
            var crate = RandomCrate();
            yield return WalkTo(crate.transform.position, .75f);
            yield return new WaitForSeconds(.5f);
            GrabFrom(crate);
            yield return new WaitForSeconds(thinktime);
            var counter = RandomCounter();
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
            Held.transform.SetParent(null);
            Held.transform.position = transform.position;
            Held.GetComponent<BoxCollider2D>().enabled = true;
        }
        Held = null;

    }

    private void GrabFrom(Crate crate)
    {
        Held = Instantiate(crate.FoodPrefab);
        Held.transform.SetParent(transform);
        Held.transform.localPosition = Vector3.up;
        Held.GetComponent<BoxCollider2D>().enabled = false;
    }

    public IEnumerator WalkTo(Vector2 position, float distance)
    {
        while(Vector2.SqrMagnitude((Vector2)transform.position - position) > distance * distance)
        {
            yield return new WaitForFixedUpdate();
            var direction = (position - (Vector2)transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.fixedDeltaTime);
        }

    }

    
}
