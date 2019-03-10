using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapperMB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AppStateManager.Instance.PushState(new MenuState());
    }
}
