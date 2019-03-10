using UnityEngine;
using System.Collections;

/// <summary>
/// Proxy class for User Input for Player Controls
/// </summary>
public class PlayerInputProxy : IInputProxy
{
    public float GetAxis(string axis)
    {
        return Input.GetAxis(axis);
    }

    public bool GetButtonDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName);
    }

    public bool GetButtonUp(string buttonName)
    {
        return Input.GetButtonUp(buttonName);
    }
}
