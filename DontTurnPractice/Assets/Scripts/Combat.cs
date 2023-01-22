using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public float timer; 
    private Animator animator;
    public int punch; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 

        if (punch >= 2)
        {
            punch = 0; 
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            AnimationPunch(); 
        }

        if(timer > 2f && punch != 0)
        {
            punch = 0; 
        }
    }

    public void AnimationEvents()
    {

    }
    
    public void AnimationPunch()
    {
        timer = 0;
        punch++;
        animator.SetInteger("punches", punch);
    }

}
