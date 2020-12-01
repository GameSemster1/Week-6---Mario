using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // [SerializeField] GameObject Enenmy;
    [SerializeField] string triggeringTag;

    void Start()
    {
	    triggeringTag = this.tag;
    }

    private void OnTrigger2D(Collider2D other)
    {
	    if (triggeringTag == other.tag)
	    {
		    Destroy(this.gameObject);
	    }
    }
}
