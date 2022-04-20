using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;

    

  
    void Update()
    {
        // Este liikkuu vasemmalle
        //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -11f)
        {
            Destroy(gameObject);
        }

    }
}
