using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listens for a return input to progress from menu to gamestate
/// </summary>
public class MenuInputListenerMB : MonoBehaviour
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
        AppStateManager.Instance.PushState(new GameState());
    }
}
