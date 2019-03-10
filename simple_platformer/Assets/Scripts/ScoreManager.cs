using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Manages the tracking and saving of scores
/// </summary>
public class ScoreManager
{
    private Score _currentScore;
    public static readonly string LastScoreFilePath = Application.streamingAssetsPath + "/lastscore.txt";
    public static readonly string ScoreFilePath = Application.streamingAssetsPath + "/scores.txt";

    public ScoreManager()
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

    public void SaveToFile()
    {

        if (!File.Exists(LastScoreFilePath))
        {
            File.Create(LastScoreFilePath);
        }

        string content;
        using (StreamReader sr = new StreamReader(ScoreFilePath))
        {
            content = sr.ReadToEnd();
        }

        string newEntry = "KNIGHT:" + GetCurrentScoreValue().ToString() + "\r\n";        

        using (StreamWriter sw = new StreamWriter(ScoreFilePath))
        {
            sw.Write(newEntry);
            sw.Write(content);
            sw.Close();
        }
    }    
}
