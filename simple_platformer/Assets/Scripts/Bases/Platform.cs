using UnityEngine;
using System.Collections;

/// <summary>
/// Base Platform Entity
/// </summary>
public class Platform : PhysicsEntity
{
    public Platform(string name, string tag, IPhysicsBody2D body):base(name, tag, body)
    {

    }
}
