using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpForce = 5f;
    private Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0f, 0f) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rigid.velocity.y) < 0.001f)
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

}
