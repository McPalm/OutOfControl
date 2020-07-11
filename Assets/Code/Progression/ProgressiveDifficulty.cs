using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressiveDifficulty : MonoBehaviour
{
    public RobotAI[] Robots;

    int stage = 0;


    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > stage * 30f)
        {
            stage++;
            Debug.Log($"Difficulty: {stage}");
            foreach(var robot in Robots)
            {
                robot.walkSpeed = 1.75f + stage * .15f;
                if (stage > 15)
                    robot.thinktime = 0f;
                else if (stage > 5)
                    robot.thinktime = .5f;
                if (stage == 4)
                    robot.enabled = true;
            }
        }
    }
}
