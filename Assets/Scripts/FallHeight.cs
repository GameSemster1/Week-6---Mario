using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallHeight : MonoBehaviour
{
    
/*    [SerializeField] float minImpulseForExplosion = 1.0f;
    [SerializeField] GameObject Player;
    [SerializeField] float BrokenEffectTime = 2.0f;

    private Rigidbody2D rb;
    void Start() {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        float impulse = collision.relativeVelocity.magnitude * rb.mass;
        if (impulse > minImpulseForExplosion) {
            Explosion();
        }
    }

    void Explosion() {
        Player.GetComponent<MovementPlayer>().speed *= 0.5f;
    //    WaitForSeconds(BrokenEffectTime);
        Player.GetComponent<MovementPlayer>().speed *= 2.0f;
    }*/
}
