using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will be used to allow messaging/signalling to take place between objects without using the Unity Message system.
/// </summary>
public class LevelEventManager
{
    public LevelEventManager()
    {

    }

    public delegate void LevelEventHandler(object sender);
    public delegate void LevelPickupEventHandler(object sender, Pickup pickup);
    public event LevelEventHandler OnLevelStart;
    public event LevelEventHandler OnLevelCompleted;
    public event LevelEventHandler OnPlayerHit;
    public event LevelPickupEventHandler OnPlayerPickup;
    public event LevelEventHandler OnPlayerDeath;

    /// <summary>
    /// To be called only by the StateManager to signal the level is started
    /// </summary>
    public void SignalLevelStart(object sender)
    {        
        if (OnLevelStart != null) OnLevelStart(sender);        
    }

    /// <summary>
    /// To be called only by the LevelEndPoint to signal the level has completed
    /// </summary>
    public void SignalLevelCompleted(object sender)
    {        
        if(OnLevelCompleted != null) OnLevelCompleted(sender);        

        if (AppStateManager.Instance.GetCurrentState().Name == GameState.name)
        {
            AppStateManager.Instance.ReplaceCurrentState(new GameOverState());
        }
    }

    public void SignalPlayerPickup(object sender, Pickup pickup)
    {
        if (OnPlayerPickup != null) OnPlayerPickup(sender, pickup);
    }

    /// <summary>
    ///To be called only bt the Player or life manager to singal the player has died 
    /// </summary>
    public void SignalPlayerDeath(object sender)
    {
        if (OnPlayerDeath != null) OnPlayerDeath(sender);        

        if (AppStateManager.Instance.GetCurrentState().Name == GameState.name)
        {
            AppStateManager.Instance.PopCurState(); //making the assuption this is the game state
        }
    }

    /// <summary>
    /// To be called only by the Player controller to signal the Player has been hit by an enemy or hazard
    /// </summary>
    public void SignalPlayerHit(object sender)
    {
        if (OnPlayerHit != null) OnPlayerHit(sender);        
    }
}
