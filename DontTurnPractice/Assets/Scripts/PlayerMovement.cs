using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 50f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private bool doubleJump;
    public float doubleJumpingPower = 12f;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float walljumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f); 

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return; 
        }

        horizontal = Input.GetAxisRaw("Horizontal");

       

        if(IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false; 
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(IsGrounded() || doubleJump)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, doubleJump ? doubleJumpingPower : jumpingPower);

                doubleJump = !doubleJump; 
            }


        }


         
        if(Input.GetButtonUp("Jump") && rigidBody.velocity.y > 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f); 
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash()); 
        }

        WallSlide();
        WallJump(); 

        if(!isWallJumping)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y); 
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale; 

            transform.Rotate(0f, 180f, 0f); 
        }
    }

    private bool IsWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }   
   
    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            walljumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping)); 
        }
        else
        {
            walljumpingCounter -= Time.deltaTime; 
        }

        if (Input.GetButtonDown("Jump") && walljumpingCounter > 0f)
        {
            isWallJumping = true;
            rigidBody.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            walljumpingCounter = 0f; 

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                //Vector3 localScale = transform.localScale;
                //localScale.x *= -1f;
                //transform.localScale = localScale; 

                transform.Rotate(0f, 180f, 0f);
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration); 
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false; 
    }

    private void WallSlide()
    {
        if(IsWall() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, Mathf.Clamp(rigidBody.velocity.y, -wallSlidingSpeed, float.MaxValue)); 
        }
        else
        {
            isWallSliding = false;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rigidBody.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true; 
    }
}
