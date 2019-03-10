using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMB : MonoBehaviour
{
    protected PlayerController _controller;
    public float moveSpeed = 25.0f;
    public float maxSpeed = 5.0f;
    public float jumpForce = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = new PlayerController(
            name, 
            tag, 
            new UnityCapsuleBody2D(transform, GetComponent<CapsuleCollider2D>(), GetComponent<Rigidbody2D>()),
            new PlayerInputProxy()
            );

        _controller.moveSpeed = moveSpeed;
        _controller.jumpForce = jumpForce;
        _controller.maxSpeed = maxSpeed;

        //hook up out destroy request events
        _controller.OnDestroy += OnControllerDestroy;
        _controller.OnDelayDestroy += OnControllerDelayDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        _controller.Update(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _controller.OnCollisionEnter2D(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _controller.OnCollisionExit2D(collision);
    }

    void OnControllerDestroy()
    {
        DestroyImmediate(this);
    }

    void OnControllerDelayDestroy()
    {
        Destroy(this);
    }

}
