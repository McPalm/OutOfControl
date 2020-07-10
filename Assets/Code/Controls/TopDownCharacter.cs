using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacter : MonoBehaviour , CharacterInput.IControllable
{

    public InputToken InputToken { get; set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (Vector3)InputToken.Direction * .1f;
    }
}
