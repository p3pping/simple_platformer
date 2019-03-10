using UnityEngine;
using System.Collections;

public class UnityCapsuleBody2D : UnityPhysicsBody
{

    public UnityCapsuleBody2D(Transform transform, CapsuleCollider2D collider, Rigidbody2D rigidbody):base(transform, collider, rigidbody)
    {
    }

    public override Vector2 GetSize()
    {
        return ((CapsuleCollider2D)_collider).size;
    }
}
