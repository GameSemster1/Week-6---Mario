using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
	[SerializeField] float minImpulseForExplosion = 1.0f;
	[SerializeField] string Tag;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag(Tag))
		{
			float impulse = Mathf.Abs(collision.relativeVelocity.y);
			if (impulse > minImpulseForExplosion)
			{
				Destroy(this.gameObject);
			}
			else
			{
				collision.collider.GetComponent<MovementPlayer>().ReSpawn();
			}
		}
	}
}