using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// AppStateManager is a singleton that will be used to manage the current state of the app.
/// </summary>
public class AppStateManager
{
    
    private static AppStateManager instance;
    /// <summary>
    /// Singleton Access Instance
    /// </summary>
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

    private AppStateManager(AppState initialState)
    {        
        _stateStack = new Stack<AppState>();        
        _stateStack.Push(initialState);
    }

    /// <summary>
    /// Gets the current state
    /// </summary>
    /// <returns></returns>
    public AppState GetCurrentState()
    {
        return (_stateStack.Count == 0)? null :_stateStack.Peek();
    }

    /// <summary>
    /// Clears the entire State manager of all states
    /// </summary>
    public void PopAllStates()
    {
        while(_stateStack.Count > 0)
        {
            PopCurState();
        }
    }

    /// <summary>
    /// Replaces the current state with the supplied
    /// </summary>
    /// <param name="state"></param>
    public void ReplaceCurrentState(AppState state)
    {
        _stateStack.Peek().Cleanup();
        _stateStack.Pop();
        _stateStack.Push(state);
        _stateStack.Peek().Init();
    }

    /// <summary>
    /// Pops the top most state
    /// </summary>
    public void PopCurState()
    {
        _stateStack.Peek().Cleanup();
        _stateStack.Pop();
        //normally you wouldnt re-init, but because of the scope and time soncstraints I'm prioritising functionality over Additive Scene Managenent        
        _stateStack.Peek().Init();
    }


    /// <summary>
    /// Pushes a new state onto the stack
    /// </summary>
    /// <param name="newState"></param>
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
