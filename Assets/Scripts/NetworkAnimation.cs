using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode.Components;


public class NetworkAnimation : NetworkAnimator
{
    protected override bool OnIsServerAuthoritative() {
        return false;
    }

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool sideMovement = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool jumping = Input.GetKey(KeyCode.W);
        bool isRunning = animator.GetBool("isRunning");
        bool isJumping = animator.GetBool("isJumping");

        if(!IsOwner) return;
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
        }
    }
}
