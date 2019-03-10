using UnityEngine;
using System.Collections;

public class BreakablePlatformMB : MonoBehaviour
{
    private BreakablePlatform _platform;
    public int maxHits;
    // Use this for initialization
    void Start()
    {
        _platform = new BreakablePlatform(
            name,
            tag,
            new UnityBoxBody2D(transform, GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>()),
            maxHits
            );
        _platform.OnDelayDestroy += Platform_OnDelayDestroy;        
    }

    private void Platform_OnDelayDestroy()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        _platform.OnCollisionEnter2D(collision);
    }
}
