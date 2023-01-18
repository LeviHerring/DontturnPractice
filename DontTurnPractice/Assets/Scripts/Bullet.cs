using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidbody2d;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d.velocity = transform.right * speed; 
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= -0.5f)
        {
            Destroy(gameObject); 
        }


    }
}
