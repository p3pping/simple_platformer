using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PhysicsObjects2D;

/// <summary>
/// Base Class for Unity Specific Physics Body decoupling
/// </summary>
public class UnityPhysicsBody : IPhysicsBody2D
{
    protected Rigidbody2D _rigidbody;
    protected Transform _transform;
    protected Collider2D _collider;

    public UnityPhysicsBody(Transform transform, Collider2D collider, Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
        _transform = transform;
        _collider = collider;
    }

    /// <summary>
    /// Applys a force to the body
    /// </summary>    
    public void ApplyForce(Vector2 force)
    {
        _rigidbody.AddForce(force, ForceMode2D.Force);
    }

    /// <summary>
    /// Applys an Inpulse force to the body
    /// </summary>
    public void ApplyImpulse(Vector2 impulse)
    {
        _rigidbody.AddForce(impulse, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Gets the transforms position
    /// </summary>
    public Vector2 GetPosition()
    {
        return _transform.position;
    }

    /// <summary>
    /// Gets the size of the collider
    /// </summary>
    public virtual Vector2 GetSize()
    {
        return Vector2.zero;
    }

    /// <summary>
    /// Raycasts and returns a RaycastHit2D result
    /// </summary>
    public virtual object Raycast(Vector2 start, Vector2 end)
    {
        Vector2 direction = end - start;        
        RaycastHit2D result = Physics2D.Raycast(start, direction.normalized, direction.magnitude);
        return result;
    }

    /// <summary>
    /// Projects the collider in a direction by the distance and returns any hits if overlapping
    /// </summary>
    public virtual List<object> BodyCast(Vector2 direction, Vector2 distance)
    {
        RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
        int numHits = _collider.Cast(direction, hitBuffer);
        List<object> hitList = new List<object>();
        for(int i = 0; i < numHits; i++)
        {
            hitList.Add(hitBuffer[i]);
        }
        return hitList;
    }

    public virtual void OnCollisionEnter(object collisionInfo)
    {
    }

    /// <summary>
    /// Allows the owner to let the body know there aout entering collisions
    /// It can then signal 
    /// </summary>
    public virtual void OnCollisionExit(object collisionInfo)
    {    
    }

    public void SetGravityScale(float scale)
    {
        _rigidbody.gravityScale = scale;
    }

    /// <summary>
    /// Gets/Sets the rigid bodies current velocity
    /// </summary>
    public Vector2 Velocity
    {
        get
        {
            return _rigidbody.velocity;
        }

        set
        {
            _rigidbody.velocity = value;
        }
    }
}
