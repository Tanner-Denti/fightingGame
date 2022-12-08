using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneAttack : MonoBehaviour
{
    public GameObject playerOneAttackArea = default;

    private bool playerOneAttacking = false;

    private float playerOnetimeToAttack = 0.25f;
    private float playerOnetimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerOneAttackArea = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Space to attack
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // Attacking timer for 0.25 seconds
        if(playerOneAttacking)
        {
            playerOnetimer += Time.deltaTime;

            if(playerOnetimer >= playerOnetimeToAttack)
            {
                playerOnetimer = 0;
                playerOneAttacking = false;
                playerOneAttackArea.SetActive(playerOneAttacking);
            }
        }
    }
    private void Attack()
    {
        playerOneAttacking = true;
        playerOneAttackArea.SetActive(playerOneAttacking);
    }

}
