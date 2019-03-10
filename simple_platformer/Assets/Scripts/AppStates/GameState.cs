using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// GameState state of the application
/// </summary>
public class GameState : AppState
{
    public const string name = "gamestate";
    public const string scenePath = "GameScene";

    private ScoreManager _scoreManager;
    public ScoreManager ScoreManager
    {
        get
        {
            return _scoreManager;
        }
    }

    private LevelEventManager _levelEventManager;
    public LevelEventManager LevelEventManager
    {
        get { return _levelEventManager; }
    }

    private LifeManager _lifeManager;
    public LifeManager LifeManager
    {
        get { return _lifeManager; }
    }

    public GameState():base(name, scenePath)
    {        
        _levelEventManager = new LevelEventManager();
        _scoreManager = new ScoreManager();
        _lifeManager = new LifeManager(this);
        _lifeManager.MaxLives = 3;
    }

    public override void Init()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        LoadScene();        
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _levelEventManager.SignalLevelStart(this);
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    public override void Cleanup()
    {
        _scoreManager.SaveToFile();
    }
}
