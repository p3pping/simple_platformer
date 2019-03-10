using UnityEngine;
using System.Collections;

public interface IState
{
    void Init();
    void Cleanup();
    string Name { get; set; }
}
