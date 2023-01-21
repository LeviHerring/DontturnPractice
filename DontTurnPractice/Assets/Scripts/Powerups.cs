using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Powerups : MonoBehaviour
{
    public float hold;
    public bool hasbeenPressedBefore; 
    public bool[] hasPressedOnce;
    PlayerHealth playerHealth; 
    public float timer = 0f; 
    public Image metre; 
    public PlayerMovement playerMovement;
    public bool PressedOnce;
    ProjectileFire projectileFire; 

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); 
        projectileFire = GetComponentInChildren<ProjectileFire>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(hasbeenPressedBefore)
        {
            //timer = hold; 
            metre.fillAmount = timer / 3;
        }
      

        if (timer >= 3f && hasbeenPressedBefore == false)
        {
            hold = 3f; 
            timer = 3f; 
        }

        if(timer <= 0f)
        {
            timer = 0f; 
              
            if (hasbeenPressedBefore == true)
            {
                playerHealth.hasPowerUpTooLong = true;
                foreach (bool i in hasPressedOnce)
                {
                    if (i == true)
                    {
                        playerHealth.howManyPowerUps++; 
                    }
                }
            }
            else
            {
                timer = 0f;
                playerHealth.hasPowerUpTooLong = false; 
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            projectileFire.Shoot(); 
        }


        if(Input.GetKeyDown(KeyCode.P) && hasPressedOnce[0] == false)
        {
            timer = 3f;
            hasbeenPressedBefore = true; 
            //StartCoroutine(SpeedUp()); 
            SpeedUpFunctionOn(); 

        }
        else if (Input.GetKeyDown(KeyCode.P) && hasPressedOnce[0] == true)
        {
            SpeedUpFunctionOff();
            hasbeenPressedBefore = false; 
        }

        if (Input.GetKeyDown(KeyCode.O) && hasPressedOnce[1] == false)
        {
            if (hasbeenPressedBefore == false)
            {
                timer = 3f;
                hasbeenPressedBefore = true;
                JumpHigherFunctionOn();
            }
            else
            {
                hasbeenPressedBefore = true; 
                JumpHigherFunctionOn();
            }
           
            //StartCoroutine(JumpHigher()); 
            

        }
        if (Input.GetKeyDown(KeyCode.O) && hasPressedOnce[1] == true)
        {
            //StartCoroutine(JumpHigher()); 
            JumpHigherFunctionOff();
            hasbeenPressedBefore = false; 

        }
    }


    private IEnumerator SpeedUp()
    {
        PressedOnce = true; 
        playerMovement.speed *= 1.25f;
        yield return new WaitForSeconds(5f);
        playerMovement.speed /= 1.25f;
        PressedOnce = false; 
    }

    private IEnumerator JumpHigher()
    {
        PressedOnce = true;
        playerMovement.jumpingPower *= 2f;
        yield return new WaitForSeconds(5f);
        playerMovement.jumpingPower /= 2f;
        PressedOnce = false;
    }

    public void SpeedUpFunctionOn()
    {
        hasPressedOnce[0] = true;
        playerMovement.speed *= 1.25f;
       
    }

    public void SpeedUpFunctionOff()
    {
        playerMovement.speed /= 1.25f;
        hasPressedOnce[0] = false;
    }

    public void JumpHigherFunctionOn()
    {
        hasPressedOnce[1] = true;
        playerMovement.jumpingPower *= 2f;

    }

    public void JumpHigherFunctionOff()
    {
        hasPressedOnce[1] = false;
        playerMovement.jumpingPower /= 2f;
        hold = timer; 
        metre.fillAmount = hold; 

    }


}
