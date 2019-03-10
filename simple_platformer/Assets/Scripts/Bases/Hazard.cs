using UnityEngine;
using System.Collections;

public class Hazard : PhysicsEntity
{
    public Hazard(string name, string tag, IPhysicsBody2D body):base(name, tag, body)
    {        
    }

    protected override void Cleanup()
    {

    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && IsAppStateSet() && _appState.Name == GameState.name)
        {            
            ((GameState)_appState).LevelEventManager.SignalPlayerHit(this);
        }
    }
}
