using UnityEngine;
using System.Collections;

public class BreakablePlatform : Platform
{
    private int _hitCount;
    private int _maxHits;

    public BreakablePlatform(string name, string tag, IPhysicsBody2D body, int maxHits = 2):base(name, tag, body)
    {
        _maxHits = maxHits;
        _hitCount = 0;       
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            return;
        }

        _hitCount++;        
        if (_hitCount >= _maxHits)
        {
            DelayDestroy();
            return;
        }
        UpdateSpriteColor();
    }

    private void UpdateSpriteColor()
    {
        //TODO abstract sprite access away in a lower derived class
        SpriteRenderer sprite = GameObject.Find(_name).GetComponent<SpriteRenderer>();
        Color hitColor = sprite.color;
        hitColor.r -= ((1.0f / _maxHits) * _hitCount);     
        hitColor.g = 0.0f;

        sprite.color = hitColor;
        
    }
}
