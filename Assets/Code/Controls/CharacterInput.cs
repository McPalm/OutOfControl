using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{

    public InputToken InputToken { get; set; }
    private void Start()
    {
        InputToken = new InputToken();
        foreach (var controllable in GetComponents<IControllable>())
        {
            controllable.InputToken = InputToken;
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if(enabled)
            InputToken.SetDirection(context.ReadValue<Vector2>());
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (enabled)
            if (context.started)
                InputToken.PressUse();
    }


    private void OnDisable()
    {
        InputToken.SetDirection(Vector2.zero);
    }

    public interface IControllable
    {
        InputToken InputToken { set; }
    }
}
