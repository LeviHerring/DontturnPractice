using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespwanEnemy : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject enemy;
    bool isEnemyHere; 
    // Start is called before the first frame update
    void Start()
    {
        isEnemyHere = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnemyHere == false)
        {
            Instantiate(enemy, spawnLocation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isEnemyHere = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isEnemyHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isEnemyHere = false; 
        }
    }

}
