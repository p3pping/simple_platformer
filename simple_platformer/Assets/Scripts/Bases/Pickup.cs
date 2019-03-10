using UnityEngine;
using System.Collections;

/// <summary>
/// Base Pickup Entity
/// </summary>
public class Pickup: PhysicsEntity
{
    public Pickup(string name, string tag, IPhysicsBody2D body):base(name, tag, body)
    {

    }

    public virtual void DoAction()
    {

    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag != "Player")
        {
            return;
        }

        DoAction();
    }    
}
