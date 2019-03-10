using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerMB : MonoBehaviour
{
    private EnemyController _enemy;

    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = new EnemyController(
            name,
            tag,
            new UnityBoxBody2D(transform, GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>()),
            null
            );
        _enemy.moveSpeed = moveSpeed;

        _enemy.OnDelayDestroy += _enemy_OnDelayDestroy;
    }

    private void _enemy_OnDelayDestroy()
    {
        gameObject.SetActive(false);        
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.Update(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_enemy != null)
        {
            _enemy.OnCollisionEnter2D(collision);
        }
    }

}
