using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlles an Enemy
/// </summary>
public class EnemyController : PhysicsEntityController
{
    public float moveSpeed;
    private GameState _gameState;
    private int _moveDir = -1;
    private Vector2 _velocity;
    private float _shell;    

    public EnemyController(string name, string tag, IPhysicsBody2D body, IInputProxy inputProxy):base(name,tag,body,inputProxy)
    {
        _velocity = new Vector2(0, 0);
        _moveDir = (((int)Random.value) * 10 % 2 == 0) ? -1 : 1;
        _gameState = (AppStateManager.Instance.GetCurrentState().Name == GameState.name) ? (GameState)AppStateManager.Instance.GetCurrentState() : null;
        _shell = 0.01f;
    }


    public override void Update(float delta)
    {
        CheckAndHandleEdges();
        HandleMovement(delta);
    }

    void CheckAndHandleEdges()
    {
        Vector2 halfSize = (_body.GetSize() / 2)+ new Vector2(_shell*-2, _shell);
        Vector2 ray = new Vector2(0f, 0.3f);
        Vector2 leadingBound = _body.GetPosition();
        leadingBound.y -= halfSize.y;

        if (_moveDir == -1)
        {
            leadingBound.x -= halfSize.x;
        }
        else if (_moveDir == 1)
        {            
            leadingBound.x += halfSize.x;
        }

        
        var rayResult = ((RaycastHit2D)_body.Raycast(leadingBound, leadingBound - ray)).transform;       

        if (rayResult == null)
        {
            _moveDir *= -1;
        }
    }

    private void HandleMovement(float delta)
    {
        _velocity.x = (_moveDir * moveSpeed) * delta;
        _body.Velocity = _velocity;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player" && collision.transform.tag != "Enemy" && collision.transform.tag != "Hazard" && collision.transform.tag != "Wall")
        {
            return;
        }        

        if (collision.transform.tag == "Enemy" || collision.transform.tag == "Hazard" || collision.transform.tag == "Wall")
        {
            _moveDir *= -1;
            return;
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            //player kills us
            //signal to our MonoBehavior to destroy this gameobject
            DelayDestroy();
        }
        else
        {
            if(_gameState == null)
            {
                return;
            }

            _gameState.LevelEventManager.SignalPlayerHit(this);
        }
        
    }
}
