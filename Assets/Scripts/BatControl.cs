using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour
{
    Rigidbody2D physic;
    
    float batSpeed;
    Vector2 vec;

    void Start()
    {
        //instead of transform.gameObject I can use this.
        physic = transform.gameObject.GetComponent<Rigidbody2D>();
        batSpeed = 5;
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            vec = new Vector2(0, 1);
            physic.velocity=vec * batSpeed;
        }else if (Input.GetKey(KeyCode.S))
        {
            vec = new Vector2(0, -1);
            physic.velocity = vec * batSpeed;
        }
        else
        {
            physic.velocity = new Vector2(0, 0);
        }
        
    }
}
