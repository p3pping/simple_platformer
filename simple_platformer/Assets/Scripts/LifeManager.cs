using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages player lives
/// </summary>
public class LifeManager
{
    private GameState _gameState;
    private int _remainingLives;
    private int _maxLives;
    public int MaxLives { get { return _maxLives; } set { _maxLives = value; } }
    public int RemainingLives { get { return _remainingLives; } }

    public LifeManager(GameState gameState)
    {
        _gameState = gameState;
        gameState.LevelEventManager.OnLevelStart += LevelEventManager_OnLevelStart;
        gameState.LevelEventManager.OnPlayerHit += LevelEventManager_OnPlayerHit;        
    }

    private void LevelEventManager_OnPlayerHit(object sender)
    {
        _remainingLives--;
        if(_remainingLives <= 0)
        {
            _gameState.LevelEventManager.SignalPlayerDeath(this);
        }
    }

    private void LevelEventManager_OnLevelStart(object sender)
    {
        _remainingLives = _maxLives;
    }
}
