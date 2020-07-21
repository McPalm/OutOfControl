using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressiveDifficulty : MonoBehaviour
{
    public RobotAI[] Robots;

    int stage = 0;

    public Money Money;
    public ListOfOrders ListOfOrders;

    float dynamicFeedback = 30f;

    RobotAI RandomRobot() => Robots[Random.Range(0, Robots.Length)];

    public UnityEvent<int> OnStageChange;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > stage * 30f)
        {
            stage++;
            OnStageChange.Invoke(stage);
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
            Debug.Log($"Entering stage {stage}");
            if(stage > 7)
            {
                int currentOrders = ListOfOrders.CurrentOrders.Count;
                int maxOrders = 12 - currentOrders;
                if(maxOrders > 0)
                    ListOfOrders.PlaceBulkOrder(System.Math.Min(maxOrders, 2 + stage / 5));
            }
        }
        if(dynamicFeedback < Time.timeSinceLevelLoad)
        {
            if(Money.wallet < 0)
            {
                // do something nice
                RandomRobot().RequestedMeal = ListOfOrders.PlaceRandomOrder();
            }
            else if(Money.wallet < 0 && ListOfOrders.CurrentOrders.Count > 1)
            {
                RandomRobot().RequestedMeal = ListOfOrders.CurrentOrders[0];
                RandomRobot().RequestedMeal = ListOfOrders.CurrentOrders[1];
            }
            dynamicFeedback = Time.timeSinceLevelLoad + 10f;
        }
    }
}
