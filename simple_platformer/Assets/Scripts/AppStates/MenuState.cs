using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/// <summary>
/// Menu State state of the application
/// </summary>
public class MenuState : AppState
{
    public const string name = "menustate";
    public const string scenePath = "MenuScene";
    public MenuState() : base(name, scenePath)
    {

    }
}
