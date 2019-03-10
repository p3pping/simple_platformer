using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverInputListenerMB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SwitchToGameScene();
        }
    }

    void SwitchToGameScene()
    {        
        AppStateManager.Instance.ReplaceCurrentState(new GameState());
    }
}
