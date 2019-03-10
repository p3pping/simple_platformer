using UnityEngine;
using System.Collections;

/// <summary>
/// Attempt to Abstract Box2D collider based bodies away from Unity
/// </summary>
public class UnityBoxBody2D : UnityPhysicsBody
{

    public UnityBoxBody2D(Transform transform, BoxCollider2D collider, Rigidbody2D rigidbody):base(transform, collider, rigidbody)
    {

    }
    
    public override Vector2 GetSize()
    {
        return ((BoxCollider2D)_collider).size;
    }
}
