using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyScript : MonoBehaviour
{
    public float health = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        health = 1f; 
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PunchHitbox")
        {
            health -= 0.01f; 
        }
    }
}
