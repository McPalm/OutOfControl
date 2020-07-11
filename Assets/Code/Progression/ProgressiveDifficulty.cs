using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressiveDifficulty : MonoBehaviour
{
    public RobotAI[] Robots;

    int stage = 0;

    public Money Money;
    public ListOfOrders ListOfOrders;

    float dynamicFeedback = 30f;

    RobotAI RandomRobot() => Robots[Random.Range(0, Robots.Length)];

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > stage * 30f)
        {
            stage++;
            Debug.Log($"Difficulty: {stage}");
            foreach (var robot in Robots)
            {
                robot.walkSpeed = 1.75f + stage * .1f;
                if (stage > 15)
                    robot.thinktime = 0f;
                else if (stage > 5)
                    robot.thinktime = .5f;
                if (stage == 4)
                    robot.enabled = true;
            }
            if (stage == 2)
                Robots[1].enabled = true;
        }
        if(dynamicFeedback < Time.timeSinceLevelLoad)
        {
            if(Money.wallet < 0)
            {
                // do something nice
                RandomRobot().RequestedMeal = ListOfOrders.PlaceRandomOrder();
                Debug.Log("Trying to Help the Player!"); // ssshhh
            }
            dynamicFeedback = Time.timeSinceLevelLoad + 10f;
        }
    }
}
