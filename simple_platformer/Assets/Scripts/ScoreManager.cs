using UnityEngine;
using System.Collections;

public class ScoreManager
{
    private Score _currentScore;
    private GameState _gameState;

    public ScoreManager(GameState gameState)
    {
        _gameState = gameState;
        _gameState.LevelEventManager.OnLevelStart += LevelEventManager_OnLevelStart;        
        _currentScore = new Score("new", 0);
    }

    private void LevelEventManager_OnLevelStart(object sender)
    {        
        _currentScore = new Score("new", 0);
    }

    public void AddToScoreValue(int increase)
    {
        _currentScore.FinalScore += increase;
    }

    public int GetCurrentScoreValue()
    {
        return _currentScore.FinalScore;
    }
}
