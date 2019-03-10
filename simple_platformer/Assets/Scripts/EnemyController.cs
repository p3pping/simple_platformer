using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PhysicsEntityController
{
    private GameState _gameState;
    private int _moveDir = -1;
    private Vector2 _velocity;
    public float moveSpeed;    
    

    public EnemyController(string name, string tag, IPhysicsBody2D body, IInputProxy inputProxy):base(name,tag,body,inputProxy)
    {
        _velocity = new Vector2(0, 0);
        _moveDir = (((int)Random.value) * 10 % 2 == 0) ? -1 : 1;
        _gameState = (AppStateManager.Instance.GetCurrentState().Name == GameState.name) ? (GameState)AppStateManager.Instance.GetCurrentState() : null;
    }    

    protected override void Cleanup()
    {

    }

    public override void Update(float delta)
    {
        CheckAndHandleEdges();
        HandleMovement(delta);
    }

    void CheckAndHandleEdges()
    {
        Vector2 halfSize = _body.GetSize() / 2;
        Vector2 ray = new Vector2(0f, 0.3f);
        Vector2 bottomLeftBound = _body.GetPosition() - halfSize;

        halfSize.y *= -1;
        Vector2 bottomRightBound = _body.GetPosition() + halfSize;

        var leftResult = ((RaycastHit2D)_body.Raycast(bottomLeftBound, bottomLeftBound - ray)).transform;
        var rightResult = ((RaycastHit2D)_body.Raycast(bottomRightBound, bottomRightBound - ray)).transform;

        if (rightResult == null || leftResult == null)
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
        if (collision.transform.tag != "Player" && collision.transform.tag != "Enemy" && collision.transform.tag != "Hazard")
        {
            return;
        }        

        if (collision.transform.tag == "Enemy" || collision.transform.tag == "Hazard")
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
