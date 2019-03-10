using UnityEngine;
using System.Collections;

/// <summary>
/// Interface for basic States
/// </summary>
public interface IState
{
    void Init();
    void Cleanup();
    string Name { get; set; }
}
