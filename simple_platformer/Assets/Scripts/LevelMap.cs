using UnityEngine;
using System.Collections;

public class LevelMap
{
    private string _levelPath;

    private GameObject _platformParent;
    private GameObject _hazardParent;
    private GameObject _enemyParent;    

    public LevelMap(string filePath, GameObject platformParent, GameObject hazardParent, GameObject enemyParent)
    {
        _platformParent = platformParent;
        _hazardParent = hazardParent;
        _enemyParent = enemyParent;
    }

    public void Load()
    {
    }
}
