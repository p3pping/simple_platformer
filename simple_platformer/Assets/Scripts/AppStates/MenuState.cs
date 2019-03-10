﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuState : AppState
{
    public const string name = "menustate";
    public const string scenePath = "MenuScene";
    public MenuState() : base(name, scenePath)
    {

    }
}