using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    private Dictionary<Type, object> _persistentObjects;

    private AppStateManager()
    {
        _stateStack = new Stack<AppState>();
        _persistentObjects = new Dictionary<Type, object>();
    }

    private AppStateManager(AppState initialState)
    {        
        _stateStack = new Stack<AppState>();
        _persistentObjects = new Dictionary<Type, object>();
        _stateStack.Push(initialState);
    }

    public void PutPersistentObject<T>( object persistentObj)
    {
        Type objType = typeof(T);
        if (_persistentObjects.ContainsKey(objType))
        {
            _persistentObjects[objType] = persistentObj;
        }
        else
        {
            _persistentObjects.Add(objType, persistentObj);
        }
    }

    public object GetPersistentObject<T>()
    {
        Type objType = typeof(T);
        return (_persistentObjects.ContainsKey(objType)) ? _persistentObjects[objType] : null;
    }
    
    public void RemovePersistentObject<T>()
    {
        Type objType = typeof(T);
        if (_persistentObjects.ContainsKey(objType))
        {
            _persistentObjects.Remove(objType);
        }
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

    public void ReplaceCurrentState(AppState state)
    {
        _stateStack.Peek().Cleanup();
        _stateStack.Pop();
        _stateStack.Push(state);
        _stateStack.Peek().Init();
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
