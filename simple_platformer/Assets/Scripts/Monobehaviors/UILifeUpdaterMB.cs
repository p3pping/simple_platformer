using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// updates the life counter UI element
/// </summary>
public class UILifeUpdaterMB : MonoBehaviour
{
    public string displayText = "Lives: ";
    private Text _textUI;
    private GameState _gameState;

    private void Start()
    {
        _textUI = GetComponent<Text>();
        if(AppStateManager.Instance.GetCurrentState() is GameState)
        {
            _gameState = ((GameState)AppStateManager.Instance.GetCurrentState());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameState != null)
        {
            _textUI.text = string.Concat(displayText, _gameState.LifeManager.RemainingLives.ToString());
        }
    }
}
