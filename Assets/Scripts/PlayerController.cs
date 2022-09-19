using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
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
