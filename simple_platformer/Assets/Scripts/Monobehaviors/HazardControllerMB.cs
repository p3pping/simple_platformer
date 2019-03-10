using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
/// HazardControllerMB is a "gateway" monobehavior for Hazard Entities
/// </summary>
public class HazardControllerMB : MonoBehaviour
{
    private Hazard _hazard;
    // Start is called before the first frame update
    void Start()
    {
        _hazard = new Hazard(name,
            tag,
            new UnityBoxBody2D(transform, GetComponent<BoxCollider2D>(), GetComponent<Rigidbody2D>()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hazard.OnTriggerEnter2D(collision);
    }
}
