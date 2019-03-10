using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppState : IState
{
    private string _name;
    private string _scenePath;
    private bool _paused;

    public AppState(string name, string scenePath)
    {
        _name = name;
        _scenePath = scenePath;
        _paused = false;
    }

    public string Name { get { return _name; } set { } }
    public string ScenePath { get { return _scenePath; } private set { _scenePath = value;  } }

    public virtual void Cleanup()
    {        
    }

    public virtual void Init()
    {
        LoadScene();
    }

    public virtual void TogglePause()
    {
        _paused = !_paused;
    }

    protected virtual void LoadScene()
    {
        SceneManager.LoadScene(_scenePath, LoadSceneMode.Single);      
    }
    
}
