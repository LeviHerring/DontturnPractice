using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{
    public int howManyPowerUps; 
    public bool hasPowerUpTooLong; 
    public float powerUpLoss = 0f; 
    public float totalLost; 
    public float thrust = 100.0f; 
    private Transform ownTransform; 
    public Transform respawnSpot; 
    public float healthLost = .25f;
    public int lives = 3;
    public int heart;
    public Image[] images;
    public GameObject[] parents; 
    // Start is called before the first frame update
    void Start()
    {
        ownTransform = GetComponent<Transform>(); 
        heart = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        

        if (hasPowerUpTooLong == true)
        {

                switch (howManyPowerUps)
                {
                    case 1:
                    StartCoroutine(PowerUpDamage(0.1f));
                    break;
                    case 2:
                    StartCoroutine(PowerUpDamage(0.0001f));
                    break;
                }
            
        }

        images[heart].fillAmount -= powerUpLoss; 

        if (images[heart].fillAmount <= 0f)
        {
            images[heart].gameObject.SetActive(false);
            parents[heart].gameObject.SetActive(false);
            lives--; 
            heart++; 
        }


        if(lives == 0)
        {
            Respawn(); 
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Spike":
                images[heart].fillAmount -= healthLost; 
                break; 
        }
    }

    public void Respawn()
    {
        heart = 0;
        lives = 3;
        ownTransform.position = respawnSpot.position; 

        for (int i = 0; i <= 2; i++)
        {
            images[i].gameObject.SetActive(true);
            images[i].fillAmount = 1f;
            parents[i].gameObject.SetActive(true);
        }
    }

    private IEnumerator PowerUpDamage(float damage)
    {
        while (hasPowerUpTooLong == true)
        {
            images[heart].fillAmount -= damage;
            yield return new WaitForSeconds(1f);
        }
    
    }
      

    }


