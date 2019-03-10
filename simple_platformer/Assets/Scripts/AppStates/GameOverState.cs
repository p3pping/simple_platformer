using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GameOver state of the application
/// </summary>
public class GameOverState : AppState
{
    public const string name = "gameoverstate";
    public const string scenePath = "GameOverScene";    
    private LeaderBoard _leaderBoard;

    public GameOverState():base(name, scenePath)
    {
        _leaderBoard = new LeaderBoard();
        _leaderBoard.LoadFromFile();
    }

    public List<Score> GetTopNScores(int nScores)
    {
        return _leaderBoard.GetTopNScores(nScores);
    }
}
