using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PhysicsObjects2D
{
    public delegate void CollisionEnterHandler(object collisionInfo);
    public delegate void CollisionExitHandler(object collisionInfo);
}
/// <summary>
/// IPhysicsObject2D is an interface to allow decoupling of the required physics operations for this project
/// </summary>
public interface IPhysicsBody2D
{
    void SetGravityScale(float scale);
    void ApplyForce(Vector2 force);
    void ApplyImpulse(Vector2 impulse);
    Vector2 Velocity { get; set; }
    Vector2 GetPosition();
    Vector2 GetSize();
    object Raycast(Vector2 start, Vector2 end);
    List<object> BodyCast(Vector2 direction, Vector2 distance);
}
