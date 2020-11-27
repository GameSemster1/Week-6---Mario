using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
        [SerializeField] float speed = 5f;

    [Tooltip("Vertical acceleration when free-falling, in meters per second^2")] [SerializeField]
    float gravityAcceleration = -10.0f;

    [Tooltip("Vertical speed immediately after jumping, in meters per second")] [SerializeField]
    float jumpSpeed = 20.0f;

    [SerializeField] KeyCode keyToJump = KeyCode.Space;
    [SerializeField] float slowDownAtJump = 0.5f;
    [SerializeField] private float minSpeedForFriction = 1f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool playerWantsToJump;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        velocity = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (!controller.enabled) return;
        velocity.x = speed * Input.GetAxis("Horizontal");
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(keyToJump))
            playerWantsToJump = true;

        // isGrounded = controller.isGrounded;
        if (true/*isGrounded*/)
        {
            // character is touching the ground - allow to walk and jump.
            if (Mathf.Abs(velocity.x) < minSpeedForFriction)
                velocity.x = 0;
            if (playerWantsToJump)
            {
                velocity.y = jumpSpeed;
                velocity.x *= slowDownAtJump;
                playerWantsToJump = false;

            }
            else
            {
                velocity.y = 0;
            }
        }
        else
        {
            float deltaVelocityY = gravityAcceleration * Time.deltaTime;
            velocity.y += deltaVelocityY;
        }
    }
}
