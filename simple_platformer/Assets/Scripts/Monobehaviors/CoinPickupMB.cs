using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CoinPickupMB is a "gateway" monobehavior for CoinPickup Entities
/// </summary>
public class CoinPickupMB : MonoBehaviour
{
    public int scoreValue;
    private CoinPickup _coinPickup;

    // Start is called before the first frame update
    void Start()
    {
        _coinPickup = new CoinPickup(
            name, 
            tag, 
            new UnityCapsuleBody2D(transform, GetComponent<CapsuleCollider2D>(), GetComponent<Rigidbody2D>())
            );
        _coinPickup.SetScoreValue(scoreValue);
        _coinPickup.OnDelayDestroy += CoinPickup_OnDelayDestroy;
    }

    private void CoinPickup_OnDelayDestroy()
    {
        _coinPickup.OnDelayDestroy -= CoinPickup_OnDelayDestroy;
        gameObject.SetActive(false);
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _coinPickup.OnTriggerEnter2D(collision);
    }
}
