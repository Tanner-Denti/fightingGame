using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{

    private Rigidbody rb;
    private int speed = 7;
    private float jumpForce = 8.0f;
    private float gravityModifier = 1.5f;
    private int jumpCounter = 0;

    void Start()
        {
            rb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }
    private void Update() {
        if (!IsOwner) return;

            Vector3 movementDirection = new Vector3(0,0,0);
            Vector3 movementDirectionLeft = new Vector3(0,0,-1);
            Vector3 movementDirectionRight = new Vector3(0,0,1);
        
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
