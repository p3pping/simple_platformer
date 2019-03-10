using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents and EndZone trigger
/// </summary>
public class EndZone : PhysicsEntity
{
    const string playerTag = "Player";

    public EndZone(string name, string tag, IPhysicsBody2D body): base(name, tag, body)
    {

    }

    protected override void Cleanup()
    {

    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag != playerTag)
        {
            return;
        }

        if (IsAppStateSet() && _appState.Name == GameState.name)
        {
            ((GameState)_appState).LevelEventManager.SignalLevelCompleted(this);
        }
    }
}
