using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class TopDownCharacter : MonoBehaviour, CharacterInput.IControllable
{

    public InputToken InputToken { get; set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Moveable>().Move(InputToken.Direction * .1f);
        if (InputToken.Direction.x != 0f)
            transform.SetForward(InputToken.Direction.x);
    }

}
