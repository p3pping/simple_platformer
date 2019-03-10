using UnityEngine;
using System.Collections;

public interface IStateManager
{
    void PushState(IState newState);
    IState GetCurrentState();
    void PopCurState();
    void PopAllStates();
}
