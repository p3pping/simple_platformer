using UnityEngine;
using System.Collections;

/// <summary>
/// Decoupling Interface for Inputs
/// </summary>
public interface IInputProxy
{
    float GetAxis(string axis);
    bool GetButtonDown(string buttonName);
    bool GetButtonUp(string buttonName);
}
