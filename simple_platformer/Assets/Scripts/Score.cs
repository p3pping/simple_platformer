using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to store a score
/// </summary>
public class Score
{
    public Score(string name, int score)
    {
        _name = name;
        _score = score;
    }

    private string _name;    
    public string Name { get { return _name; } set { _name = value; } }

    private int _score;
    public int FinalScore { get { return _score; } set { _score = value; } }
}
