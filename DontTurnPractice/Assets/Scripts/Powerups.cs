using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool PressedOnce;
    ProjectileFire projectileFire; 

    // Start is called before the first frame update
    void Start()
    {
        projectileFire = GetComponentInChildren<ProjectileFire>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            projectileFire.Shoot(); 
        }


        if(Input.GetKeyDown(KeyCode.P) && PressedOnce == false)
        {
            StartCoroutine(SpeedUp()); 
        }

        if (Input.GetKeyDown(KeyCode.O) && PressedOnce == false)
        {
            StartCoroutine(JumpHigher()); 
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

}
