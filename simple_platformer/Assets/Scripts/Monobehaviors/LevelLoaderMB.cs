using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderMB : MonoBehaviour
{
    
    public GameObject platformParent;
    public GameObject enemyParent;
    public GameObject hazardParent;
    public GameObject pickupParent;
    public GameObject levelManagemntParent;

    public GameObject platformPrefab;
    public GameObject enemyPrefab;

    public GameObject wallPrefab;
    public GameObject spikesPrefab;
    public GameObject fallingPrefab;
    public GameObject breakablePrefab;
    public GameObject coinPrefab;
    public GameObject spawnPrefab;
    public GameObject endzonePrefab;

    private LevelMap _map;   


    // Start is called before the first frame update
    void Start()
    {   
        _map = new LevelMap(Application.streamingAssetsPath+"/Maps/level.map", (GameState)AppStateManager.Instance.GetCurrentState());        

        LevelMap.PrefabParentPair platPair;
        platPair.parent = platformParent;
        platPair.prefab = platformPrefab;
        _map.RegisterPrefab('P', platPair);

        LevelMap.PrefabParentPair enemyPair;
        enemyPair.parent = enemyParent;
        enemyPair.prefab = enemyPrefab;
        _map.RegisterPrefab('E', enemyPair);

        LevelMap.PrefabParentPair wallPair;
        wallPair.parent = platformParent;
        wallPair.prefab = wallPrefab;
        _map.RegisterPrefab('W', wallPair);

        LevelMap.PrefabParentPair spikePair;
        spikePair.parent = hazardParent;
        spikePair.prefab = spikesPrefab;
        _map.RegisterPrefab('S', spikePair);

        LevelMap.PrefabParentPair fallingPair;
        fallingPair.parent = hazardParent;
        fallingPair.prefab = fallingPrefab;
        _map.RegisterPrefab('F', fallingPair);

        LevelMap.PrefabParentPair breakablePair;
        breakablePair.parent = platformParent;
        breakablePair.prefab = breakablePrefab;
        _map.RegisterPrefab('B', breakablePair);

        LevelMap.PrefabParentPair coinPair;
        coinPair.parent = pickupParent;
        coinPair.prefab = coinPrefab;
        _map.RegisterPrefab('C', coinPair);

        LevelMap.PrefabParentPair spawnPair;
        spawnPair.parent = levelManagemntParent;
        spawnPair.prefab = spawnPrefab;
        _map.RegisterPrefab('+', spawnPair);

        LevelMap.PrefabParentPair endPair;
        endPair.parent = levelManagemntParent;
        endPair.prefab = endzonePrefab;
        _map.RegisterPrefab('-', endPair);


        _map.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
