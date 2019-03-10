using UnityEngine;
using System.Collections;

/// <summary>
/// Base Physics Entity Class
/// </summary>
public class PhysicsEntity : Entity
{
    protected IPhysicsBody2D _body;
    protected bool _grounded;    

    public PhysicsEntity(string name, string tag, IPhysicsBody2D body):base(name)
    {
        _tag = tag;
        _body = body;
        _grounded = false;
    }    

    /// <summary>
    /// Called from the owning object to notify a collision started
    /// </summary>    
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }

    /// <summary>
    /// Called from the owning object to notify a collision ended
    /// </summary>
    public virtual void OnCollisionExit2D(Collision2D collision)
    {

    }

    /// <summary>
    /// Called from the owning object to notify a trigger started
    /// </summary>
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    /// <summary>
    /// Called from the owning object to notify a ended started
    /// </summary>
    public virtual void OnTriggerExit2D(Collider2D collision)
    {

    }
}
