using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bootstraps the AppStateManager into the Menu screen
/// </summary>
public class BootstrapperMB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AppStateManager.Instance.PushState(new MenuState());
    }
}
