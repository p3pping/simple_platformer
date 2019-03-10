using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneMB : MonoBehaviour
{
    private EndZone _endZone;
    // Start is called before the first frame update
    void Start()
    {
        _endZone = new EndZone(name, tag, new UnityBoxBody2D(transform, GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>()));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _endZone.OnTriggerEnter2D(collision);
    }
}
