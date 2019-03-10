using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEntityController : PhysicsEntity
{
    protected IInputProxy _inputProxy;

    public PhysicsEntityController(string name, string tag, IPhysicsBody2D body, IInputProxy inputProxy):base(name, tag, body)
    {
        _inputProxy = inputProxy;
    }

    public override void Update(float delta)
    {
        ProcessInput(delta);
        ProcessMovement(delta);
    }

    protected virtual void ProcessInput(float delta)
    {
        
    }

    protected virtual void ProcessMovement(float delta)
    {

    }
}
