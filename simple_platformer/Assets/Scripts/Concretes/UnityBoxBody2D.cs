using UnityEngine;
using System.Collections;

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
