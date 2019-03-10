using UnityEngine;
using System.Collections;

public class CoinPickup : Pickup
{
    private int _scoreValue;

    public CoinPickup(string name, string tag, IPhysicsBody2D body):base(name, tag, body)
    {

    }

    public void SetScoreValue(int scoreValue)
    {
        _scoreValue = scoreValue;
    }

    public override void DoAction()
    {
        //Add points here
        if (IsAppStateSet() && _appState.Name == GameState.name)
        {
            ((GameState)_appState).ScoreManager.AddToScoreValue(_scoreValue);
        }
        DelayDestroy();
    }
}
