using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a Falling Hazard that can crush the player
/// </summary>
public class FallingHazard : PhysicsEntity
{
    private float _rayLength;
    private Vector2 _ray;
    private const float _shell = 0.01f;
    private bool _falling = false;

    public FallingHazard(string name, string tag, IPhysicsBody2D body):base(name, tag, body)
    {
        _body.SetGravityScale(0.0f);
        _grounded = false;
        _falling = false;
        _ray = new Vector2(0.0f, _rayLength);
    }

    protected override void Cleanup()
    {
        
    }

    public float RayLength {
        get { return _rayLength; }
        set {
            _rayLength = value;
            _ray = new Vector2(0.0f, _rayLength);
        }
    }

    public override void Update(float delta)
    {
        if (_grounded)
        {
            _body.Velocity = Vector2.zero;
            return;
        }

        if(CheckIsPlayerUnderneath())
        {
            StartFall();
        }
    }

    private bool CheckIsPlayerUnderneath()
    {
        Vector2 start = _body.GetPosition();
        start.y -= _body.GetSize().y / 2;
        start.y -= _shell;

        var transform = ((RaycastHit2D)_body.Raycast(start, start - _ray)).transform;

        if (transform == null || transform.tag != "Player")
        {
            return false;
        }

        return true;        
    }

    public void StartFall()
    {
        _body.SetGravityScale(1.0f);
        _falling = true;
    }

    public void StopFall()
    {
        _body.SetGravityScale(0.0f);
        _falling = false;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        string colTag = collision.transform.tag;
        if(_grounded)
        {
            return;
        }

        if(colTag == "Platform")
        {
            _grounded = true;
            StopFall();
        }

        if(colTag == "Player" && _falling && IsAppStateSet() && _appState.Name == GameState.name)
        {
            ((GameState)_appState).LevelEventManager.SignalPlayerHit(this);
        }
    }
}
