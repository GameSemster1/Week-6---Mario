using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public bool CollliderWithImpulse;
    // private Rigidbody2D rb;
    [SerializeField] string Tag;
    // Start is called before the first frame update
    void Start()
    {
        if (CollliderWithImpulse)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(Tag == collision.collider.tag)
            {
                Destroy(this.gameObject);
            }
        }
}
