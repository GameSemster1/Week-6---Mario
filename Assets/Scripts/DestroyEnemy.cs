﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] float minImpulseForExplosion = 1.0f;
    [SerializeField] GameObject Player;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impulse = collision.relativeVelocity.magnitude * rb.mass;
        if (impulse > minImpulseForExplosion)
        {
            Destroy(this.gameObject);
        }
    }

}
