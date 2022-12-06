using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoAttack : MonoBehaviour
{
    private GameObject playerTwoAttackArea = default;
    private GameObject playerTwoDefendArea = default;

    private bool playerTwoAttacking = false;
    private bool playerTwoDefending = false;

    private float playerTwoTimeToAttack = 0.25f;
    private float playerTwoTimeToDefend = 0.25f;
    private float playerTwotimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTwoAttackArea = transform.GetChild(3).gameObject;
        playerTwoDefendArea = transform.GetChild(4).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PTwoAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
           PTwoDefend();
        }
        if (Input.GetMouseButtonUp(1))
        {
           playerTwoDefending = false;
        }

        if (playerTwoAttacking)
        {
            playerTwotimer += Time.deltaTime;

            if (playerTwotimer >= playerTwoTimeToAttack)
            {
                playerTwotimer = 0;
                playerTwoAttacking = false;
                playerTwoAttackArea.SetActive(playerTwoAttacking);
            }
        }

        if (playerTwoDefending)
        {
            playerTwotimer += Time.deltaTime;

            if (playerTwotimer >= playerTwoTimeToDefend)
            {
                playerTwotimer = 0;
                playerTwoDefending = false;
                playerTwoDefendArea.SetActive(playerTwoDefending);
            }
        }
    }
    private void PTwoAttack()
    {
        playerTwoAttacking = true;
        playerTwoDefending = false;
        playerTwoAttackArea.SetActive(playerTwoAttacking);
    }
    private void PTwoDefend()
    {
       playerTwoDefending = true;
       playerTwoAttacking = false;
       playerTwoDefendArea.SetActive(playerTwoDefending);
    }

    public bool PlayerTwoDefending
    {
       get { return playerTwoDefending; }
    }
}
