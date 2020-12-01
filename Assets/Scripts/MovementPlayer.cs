using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
	[SerializeField] public float speed = 5f;
	[SerializeField] public float jumpForce = 5f;
	public float shoeJumbForce = 10f;

	public bool brokenLegs = false;
	public float brokenLegsTime = 10;
	public string brokenLegsTag;
	public float brokenLegsImpulse;

	private float brokenLegsTimer;

	public bool shoes = false;
	public string shoesTag;

	private Rigidbody2D rigid;
	private Vector3 startingPoint;

	void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		startingPoint = transform.position;
		baseDrag = rigid.drag;
	}

	void Update()
	{
		if (brokenLegs)
		{
			brokenLegsTimer -= Time.deltaTime;
			if (brokenLegsTimer < 0)
			{
				brokenLegs = false;
				brokenLegsTimer = 0;
			}
		}

		var move = Input.GetAxis("Horizontal");

		var rigidVelocity = rigid.velocity;
		rigidVelocity.x = move * speed * (brokenLegs ? 0.5f : 1);
		rigid.velocity = rigidVelocity;

		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
		{
			rigid.AddForce(new Vector2(0, (shoes ? shoeJumbForce : jumpForce)), ForceMode2D.Impulse);
		}
	}

	public void ReSpawn()
	{
		transform.position = startingPoint;
		brokenLegs = false;
		shoes = false;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag(brokenLegsTag) && !shoes && !sliding)
		{
			if (Mathf.Abs(other.relativeVelocity.y) > brokenLegsImpulse)
			{
				brokenLegs = true;
				brokenLegsTimer = brokenLegsTime;
			}
		}
	}

	private bool IsGrounded => groundObjects > 0;

	private int groundObjects = 0;

	private float baseDrag;
	private int dragModifiers = 0;

	private bool sliding = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		groundObjects++;
		if (other.CompareTag(shoesTag))
		{
			shoes = true;
			Destroy(other.gameObject);
		}

		if (other.CompareTag("Wind"))
		{
			dragModifiers++;
			rigid.drag = other.GetComponent<AreaEffector2D>().drag;
		}

		if (other.CompareTag("Slide"))
		{
			sliding = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		groundObjects--;

		if (other.CompareTag("Wind"))
		{
			dragModifiers--;
			if (dragModifiers <= 0)
				rigid.drag = baseDrag;
		}

		if (other.CompareTag("Slide"))
		{
			sliding = false;
		}
	}
}