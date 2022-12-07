using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody rb;
        private int speed = 7;
        private float jumpForce = 8.0f;
        private float gravityModifier = 1.5f;
        private int jumpCounter = 0;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
            // Physics.gravity = new Vector3(0, -9.8F, 0);

        }

        // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            // Physics.gravity = gravityModifier;

            // The GameObjects
            string playerOne = "playerOne";
            string playerTwo = "playerTwo";

            // Different Movement for the player
            Vector3 movementDirection = new Vector3(0,0,0);
            Vector3 movementDirectionLeft = new Vector3(0,0,-1);
            Vector3 movementDirectionRight = new Vector3(0,0,1);

           // Player 1 Movement (red) wasd
           if(gameObject.name == playerOne)
           {
                // Jump up
                if (Input.GetKeyDown(KeyCode.W) && jumpCounter < 2)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
                //haven't added movement direction. Will need to add functionality to drop through certain structures, otherwise just do a crouch animation. 
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(movementDirection * Time.deltaTime * speed);
                }
                // Move Left
                if (Input.GetKey(KeyCode.A))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(-1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }
                // Move Right
                if (Input.GetKey(KeyCode.D))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }
           }
           
           // Player 2 Movement (green) arrow keys
           if(gameObject.name == playerTwo)
           {
                // Jump up
                if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCounter < 2)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
                //haven't added movement direction. Will need to add functionality to drop through certain structures, otherwise just do a crouch animation. 
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(movementDirection * Time.deltaTime * speed);
                }
                // Move Left
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(-1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }
                // Move Right
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(1,0,0));
                    transform.Translate(movementDirectionRight * Time.deltaTime * speed);
                }
           }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Make it so that players can run through each other sometimes without moving the other. 
            // Make it so that if I am falling, I cannot land on another player, preventing my jump from resetting. 
            if (collision.gameObject.CompareTag("Platform"))
            {
               jumpCounter = 0;
            }
        }
    }
}

