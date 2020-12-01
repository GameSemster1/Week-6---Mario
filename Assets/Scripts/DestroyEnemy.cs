using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] float minImpulseForExplosion = 1.0f;
    [SerializeField] string Tag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        	if(Tag == collision.collider.tag)
			{
        		float impulse = collision.relativeVelocity.y * 1;
        		if ((-1)*impulse > minImpulseForExplosion)
        		{
					Destroy(this.gameObject);
        		}
				else
				{
					collision.collider.GetComponent<DestroyPlayer>().CollliderWithImpulse = true;
					//collision.collider.GetComponent<DestroyPlayer>();
				}
			}

	}
   
}

