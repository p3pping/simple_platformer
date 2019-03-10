using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds delegates used to signal to owning classes about actions the entity wishs to perfom
/// </summary>
namespace EntityDelegates
{
    public delegate void CollisionEnterHandler(Collider2D collision);
    public delegate void CollisionexitHandler(Collider2D collision);
    public delegate void DestroyEventHandler();
}

/// <summary>
/// Base Entity class for our attempt and Unity Decoupling/Abstraction
/// </summary>
public class Entity
{
    protected string _name;
    protected string _tag;
    protected AppState _appState;

    public Entity(string name)
    {
        _name = name;
        _appState = AppStateManager.Instance.GetCurrentState();
    }

    protected virtual void Cleanup()
    {

    }

    public string Name { get { return _name; } }
    public string Tag { get { return _tag; } set { _tag = value; } }

    /// <summary>
    /// This event will be called when an entity wants to inform the monobehavior that it is owned by it wants to be destroyed
    /// </summary>
    public event EntityDelegates.DestroyEventHandler OnDestroy;
    public event EntityDelegates.DestroyEventHandler OnDelayDestroy;


    // Update is called once per frame
    public virtual void Update(float delta)
    {
        
    }

    protected void Destroy()
    {
        Cleanup();
        OnDestroy();
    }

    protected void DelayDestroy()
    {
        OnDelayDestroy();
    }

    protected bool IsAppStateSet()
    {
        return (_appState != null);
    }    
    
}
