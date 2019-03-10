using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStateManager
{
    private static AppStateManager instance;
    public static AppStateManager Instance
    {
        get
        {
            instance = (instance == null) ? new AppStateManager() : instance;
            return instance;
        }
    }

    private Stack<AppState> _stateStack;

    private AppStateManager()
    {
        _stateStack = new Stack<AppState>();
    }

    public AppStateManager(AppState initialState)
    {
        _stateStack = new Stack<AppState>();
        _stateStack.Push(initialState);
    }

    public AppState GetCurrentState()
    {
        return (_stateStack.Count == 0)? null :_stateStack.Peek();
    }

    public void PopAllStates()
    {
        while(_stateStack.Count > 0)
        {
            PopCurState();
        }
    }

    public void PopCurState()
    {
        _stateStack.Peek().Cleanup();
        _stateStack.Pop();
        //normally you wouldnt re-init, but because of the scope and time soncstraints I'm prioritising functionality
        // I dont want to create a script just to manage what is in a scene to unload during transistion
        _stateStack.Peek().Init();
    }

    public void PushState(AppState newState)
    {
        if (_stateStack.Count > 0)
        {
            _stateStack.Peek().TogglePause();
        }
        _stateStack.Push(newState);
        _stateStack.Peek().Init();
    }
}
