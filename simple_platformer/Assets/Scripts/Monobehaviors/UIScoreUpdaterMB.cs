using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Updates the score UI tracking element
/// </summary>
public class UIScoreUpdaterMB : MonoBehaviour
{
    private Text _scoreText;
    public string displayText = "Score: ";
    private GameState _gameState;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
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
            _scoreText.text = string.Concat(displayText, _gameState.ScoreManager.GetCurrentScoreValue());
        }
    }
}
