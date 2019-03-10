using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHazardMB : MonoBehaviour
{
    public float RayLength = 1.28f; //128 pixels default
    private FallingBigBoi _fallingBoi;

    // Start is called before the first frame update
    void Start()
    {
        _fallingBoi = new FallingBigBoi(
            name,
            tag,
            new UnityBoxBody2D(transform, GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>())
            );
        _fallingBoi.RayLength = RayLength;
    }

    // Update is called once per frame
    void Update()
    {
        _fallingBoi.Update(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _fallingBoi.OnCollisionEnter2D(collision);
    }
}
