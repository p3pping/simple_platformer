using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns the player
/// </summary>
public class SpawnPointMB : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parentObject;
    private GameState _gameState;

    private void OnEnable()
    {        
        if (AppStateManager.Instance.GetCurrentState() is GameState)
        {            
            _gameState = (GameState)AppStateManager.Instance.GetCurrentState();
            _gameState.LevelEventManager.OnPlayerHit += OnPlayerHit;
            _gameState.LevelEventManager.OnLevelStart += OnLevelStart;
        }
    }

    private void OnDisable()
    {
        if (_gameState != null)
        {
            _gameState.LevelEventManager.OnPlayerHit -= OnPlayerHit;
            _gameState.LevelEventManager.OnLevelStart -= OnLevelStart;
        }
    }

    public void Spawn(object activator)
    {        
        GameObject newInstance;

        if (parentObject != null)
        {
            newInstance = GameObject.Instantiate(prefab, transform.position, Quaternion.identity, parentObject.transform);
        }
        else
        {
            newInstance = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }

    public void OnLevelStart(object sender)
    {        
        Spawn(sender);
    }

    public void OnPlayerHit(object sender)
    {
        DebugHelpers.TeleportPlayerToSpawn();
    }
}
