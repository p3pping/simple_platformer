using UnityEngine;
using System.Collections;

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

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public virtual void OnCollisionExit2D(Collision2D collision)
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {

    }
}
