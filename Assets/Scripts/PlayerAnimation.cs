using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // the gameObjects
        string playerOne = "playerOne";
        string playerTwo = "playerTwo";

        // Player inputs
        bool sideMovement = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool sideMovement2 = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        bool jumping = Input.GetKey(KeyCode.W);
        bool jumping2 = Input.GetKey(KeyCode.UpArrow);
        bool attacking = Input.GetKey(KeyCode.Space);
        bool attacking2 = Input.GetMouseButtonDown(0);

        // Animation variables
        bool isRunning = animator.GetBool("isRunning");
        bool isJumping = animator.GetBool("isJumping");
        bool isAttacking = animator.GetBool("isAttacking");


        // Animations that affect player One
        if(gameObject.name == playerOne)
        {
            // Sideways movement animations
            if(!isRunning && sideMovement)
            {
                animator.SetBool("isRunning", true);
            }

            if(isRunning && !sideMovement)
            {
                animator.SetBool("isRunning", false);
            }

            // Jumping Animation
            if(!isJumping && jumping)
            {
                animator.SetBool("isJumping", true);
            }

            if(isJumping && !jumping)
            {
                animator.SetBool("isJumping", false);
            }

            // Attacking Animation
            if(!isAttacking && attacking)
            {
                animator.SetBool("isAttacking", true);
            }

            if(isAttacking && !attacking)
            {
                animator.SetBool("isAttacking", false);
            }
        }

        // Animations that affect Player Two
        if(gameObject.name == playerTwo)
        {
            // Sideways movement animations
            if(!isRunning && sideMovement2)
            {
                animator.SetBool("isRunning", true);
            }

            if(isRunning && !sideMovement2)
            {
                animator.SetBool("isRunning", false);
            }

            // Jumping Animation
            if(!isJumping && jumping2)
            {
                animator.SetBool("isJumping", true);
            }

            if(isJumping && !jumping2)
            {
                animator.SetBool("isJumping", false);
            }

            // Attacking Animation
            if (!isAttacking && attacking2)
            {
                animator.SetBool("isAttacking", true);
            }

            if (isAttacking && !attacking2)
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }
}
