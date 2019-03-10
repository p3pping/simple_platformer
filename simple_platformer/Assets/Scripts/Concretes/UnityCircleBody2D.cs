﻿using UnityEngine;
using System.Collections;

public class UnityCircleBody2D : UnityPhysicsBody
{

    public UnityCircleBody2D(Transform transform, CircleCollider2D collider, Rigidbody2D rigidbody):base(transform, collider, rigidbody)
    {
    }

    public override Vector2 GetSize()
    {
        CircleCollider2D collider = (CircleCollider2D)_collider;
        return new Vector2(collider.radius, collider.radius);
    }
}