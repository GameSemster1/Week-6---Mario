using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    
    [SerializeField] float speed = 7f;
    [SerializeField] Transform start = null;
    [SerializeField] Transform end = null; 

    private Vector3 velocity;
    bool moveFromStartToEnd = true;
    void FixedUpdate()
    {
        float deltaX = speed * Time.fixedDeltaTime;
        if (moveFromStartToEnd) {
            transform.position = Vector3.MoveTowards(transform.position, end.position, deltaX);
        } else {  // move from end to start
            transform.position = Vector3.MoveTowards(transform.position, start.position, deltaX);
        }
        
        if (transform.position == start.position) {
            moveFromStartToEnd = true;
        } else if (transform.position == end.position) {
            moveFromStartToEnd = false;
        }
        
    }

}
