using UnityEngine;
using System.Collections;

public class PlayerController : PhysicsEntityController
{
    private Vector2 _moveForce;
    private Vector2 _jumpForce;
    
    public float moveSpeed = 1f;
    public float jumpForce = 2f;
    public float maxSpeed = 1f;    

    public PlayerController(string name, string tag, IPhysicsBody2D body, IInputProxy inputProxy): base(name,tag,body,inputProxy)
    {
        _moveForce = new Vector2(0f, 0f);
        _jumpForce = new Vector2(0f, jumpForce);
        _grounded = false;

        if (IsAppStateSet() && _appState is GameState)
        {
            ((GameState)_appState).LevelEventManager.OnPlayerHit += LevelEventManager_OnPlayerHit;
        }
    }

    protected override void Cleanup()
    {
        if (IsAppStateSet() && _appState is GameState)
        {
            ((GameState)_appState).LevelEventManager.OnPlayerHit -= LevelEventManager_OnPlayerHit;
        }        
    }

    protected override void ProcessInput(float delta)
    {
        ProcessHorzontal();
        ProcessJump();        
    }

    protected override void ProcessMovement(float delta)
    {
        _body.ApplyForce(_moveForce);
        GovernVelocity();
    }

    private void ProcessHorzontal()
    {        
        _moveForce.x = _inputProxy.GetAxis("Horizontal") * moveSpeed;
    }

    private void ProcessJump()
    {
        if(_inputProxy.GetButtonDown("Jump") && _grounded)
        {
            Jump();
        }
    }
    
    private void Jump()
    {
        _jumpForce.y = jumpForce;
        _body.ApplyImpulse(_jumpForce);
        _grounded = false;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {        
        if(collision.transform.tag == "Platform" || collision.transform.tag == "Hazard")
        {            
            _grounded = true;
        }
    }

    private void GovernVelocity()
    {
        if(Mathf.Abs(_body.Velocity.x) > maxSpeed)
        {
            Vector2 governedVel = _body.Velocity;
            governedVel.x = Mathf.Sign(_body.Velocity.x) * maxSpeed;
            _body.Velocity = governedVel;
        }
    }


    private void LevelEventManager_OnPlayerHit(object sender)
    {
        _body.Velocity = Vector2.zero;
    }
}
