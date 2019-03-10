using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// LeaderBoard tracks score registered to it
/// </summary>
public class LeaderBoard
{
    private List<Score> _scores;

    public LeaderBoard()
    {
        _scores = new List<Score>();
    }

    /// <summary>
    /// Registers the score
    /// </summary>
    /// <param name="newScore"></param>
    /// <returns>True if it is a new HighScore</returns>
    public bool RegisterScore(Score newScore)
    {
        SortScoresDescending();
        bool isHighScore = false;

        if(newScore.FinalScore > _scores[0].FinalScore)
        {
            isHighScore = true;
        }
        _scores.Add(newScore);

        return isHighScore;
    }

    /// <summary>
    /// Returns the Highest current score on the leaderboard
    /// </summary>
    /// <returns></returns>
    public Score GetHighScore()
    {
        SortScoresDescending();
        return _scores[0];
    }

    /// <summary>
    /// Gets a list of the top N scores in descending order
    /// </summary>
    /// <param name="topN"></param>
    /// <returns></returns>
    public List<Score> GetTopNScores(int topN)
    {
        SortScoresDescending();
        int nScores = Mathf.Min(_scores.Count, topN);
        return _scores.Take(nScores).ToList();
    }

    /// <summary>
    /// Sorts the scores in a descending order
    /// </summary>
    private void SortScoresDescending()
    {
        _scores = _scores.OrderByDescending(s => s.FinalScore).ToList();
    }
    

    public void LoadFromFile()
    {
        if (!File.Exists(ScoreManager.ScoreFilePath))
        {
            File.Create(ScoreManager.ScoreFilePath);
            return;
        }
        
        using (StreamReader sr = new StreamReader(ScoreManager.ScoreFilePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var parts = line.Split(':');
                int score;
                int.TryParse(parts[1].Trim(), out score);
                Score newScore = new Score(parts[0], score);
                _scores.Add(newScore);
            }
            sr.Close();
        }
    }
}
