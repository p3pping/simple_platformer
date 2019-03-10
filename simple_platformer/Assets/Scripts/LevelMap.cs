using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelMap
{
    public struct PrefabParentPair
    {
        public GameObject prefab;
        public GameObject parent;
    }

    private string _filePath;
    private Vector2 _gridSize;
    private Dictionary<char, PrefabParentPair> _prefabMap;
    private GameState _state;
    private int _uniqueSuffix;

    public LevelMap(string filePath, GameState state)
    {
        _filePath = filePath;
        _prefabMap = new Dictionary<char, PrefabParentPair>();
        _state = state;
        _uniqueSuffix = 0;
    }

    public void RegisterPrefab(char alias, PrefabParentPair prefabPair)
    {
        _prefabMap.Add(alias, prefabPair);
    }

    public void Load()
    {
        //first line = width
        //second line = height
        //subsequent lines are map data
        //thrid - grid size (one value all grids are considerd squares for simplicity)
        using (StreamReader sr = new StreamReader(_filePath))
        {
            int width = 0;
            int.TryParse(sr.ReadLine().Trim(), out width);
            int height = 0;
            int.TryParse(sr.ReadLine().Trim(), out height);
            float size = 0;
            float.TryParse(sr.ReadLine().Trim(), out size);

            for (int y = 0; y < height; y++)
            {
                char[] line = sr.ReadLine().ToCharArray();
                for (int x = 0; x < width; x++)
                {
                    char alias = line[x];
                    if (_prefabMap.ContainsKey(alias))
                    {
                        //This is where I was intending to use the PrefabPool/s but I didnt get time to optimize this solution by using them.
                        var pair = _prefabMap[alias];
                        var obj = GameObject.Instantiate(pair.prefab, new Vector2(x * size, (y * size) * -1), Quaternion.identity, pair.parent.transform);
                        obj.name = string.Concat(obj.name, _uniqueSuffix);
                        obj.SetActive(true);
                        _uniqueSuffix++;
                    }
                }
            }
        }

        _state.LevelEventManager.SignalLevelStart(this);
    }
}
