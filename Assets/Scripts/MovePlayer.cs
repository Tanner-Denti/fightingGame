using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

using Actors;

namespace Scripts
{
    public class MovePlayer : MonoBehaviour
    {
        Player player;
        private Rigidbody rb;

        private int speed;
        private int jumpCounter;
        private float jumpForce;

        private float gravityModifier = 1.5f;
        

        public MovePlayer(Player player)
        {
            this.player = player;
            rb = player.GetComponent<Rigidbody>();

            speed = player.GetSpeed();
            jumpCounter = player.GetJumpCounter();
            jumpForce = player.GetJumpForce();

            Physics.gravity *= gravityModifier;
        }


        private void Move()
        {

            string playerOne = "playerOne";
            string playerTwo = "playerTwo";

            // Player 1 Movement (red) wasd
            if (Input.GetKeyDown(KeyCode.W) && gameObject.name == playerOne && jumpCounter < 2)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCounter++;
            }
            //haven't added movement direction. Will need to add functionality to drop through certain structures, otherwise just do a crouch animation. 
            if (Input.GetKey(KeyCode.S) && gameObject.name == playerOne)
            {
                transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.A) && gameObject.name == playerOne)
            {
                transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.D) && gameObject.name == playerOne)
            {
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
            }

            // Player 2 Movement (green) arrow keys
            if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.name == playerTwo && jumpCounter < 2)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCounter++;
            }
            //haven't added movement direction. Will need to add functionality to drop through certain structures, otherwise just do a crouch animation. 
            if (Input.GetKey(KeyCode.DownArrow) && gameObject.name == playerTwo)
            {
                transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && gameObject.name == playerTwo)
            {
                transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.RightArrow) && gameObject.name == playerTwo)
            {
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
            }

        }

        private void resetJump(Collision collision)
        {
            // Make it so that players can run through each other sometimes without moving the other. 
            // Make it so that if I am falling, I cannot land on another player, preventing my jump from resetting. 
            if (collision.gameObject.CompareTag("Platform"))
            {
                jumpCounter = 0;
            }
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    // Make it so that players can run through each other sometimes without moving the other. 
        //    // Make it so that if I am falling, I cannot land on another player, preventing my jump from resetting. 
        //    if (collision.gameObject.CompareTag("Platform"))
        //    {
        //        jumpCounter = 0;
        //    }
        //}
    }

}


