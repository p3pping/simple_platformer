using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A very simple very naive targeted follow camera
/// </summary>
public class SimpleTargetCamMB : MonoBehaviour
{
    public GameObject target;
    public float offset;
    private GameState _gameState;


    private void OnEnable()
    {
        if (AppStateManager.Instance.GetCurrentState() is GameState)
        {
            _gameState = (GameState)AppStateManager.Instance.GetCurrentState();
            _gameState.LevelEventManager.OnLevelStart += LevelEventManager_OnLevelStart;
            FindAndTargetPlayer();
        }
    }

    private void OnDisable()
    {
        if(_gameState == null)
        {
            return;
        }
        _gameState.LevelEventManager.OnLevelStart -= LevelEventManager_OnLevelStart;
    }

    private void LevelEventManager_OnLevelStart(object sender)
    {
        FindAndTargetPlayer();
    }

    void FindAndTargetPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            FindAndTargetPlayer();
            return;
        }

        transform.position = target.transform.position + new Vector3(0, 0, offset);
    }
}
