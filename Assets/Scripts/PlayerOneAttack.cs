using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private GameObject defendArea = default;

    private bool attacking = false;

    private bool defending = false;

    private float timeToAttack = 0.25f;
    private float timeToDefend = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(3).gameObject;
        defendArea = transform.GetChild(4).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Space to attack
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // Q to defend if Q is pressed
        if(Input.GetKeyDown(KeyCode.Q))
        {
           Defend();
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
           defending = false;
        }    

        // Attacking timer for 0.25 seconds
        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

        // Defending timer for 0.25 seconds
        if (defending)
        {
            timer += Time.deltaTime;

            if (timer >= timeToDefend)
            {
                timer = 0;
                defending = false;
                defendArea.SetActive(defending);
            }
        }
    }
    private void Attack()
    {
        attacking = true;
        defending = false;
        attackArea.SetActive(attacking);
    }

    private void Defend()
    {
       defending = true;
       attacking = false;
       defendArea.SetActive(defending);
    }

    public bool Defending
    {
       get { return defending; }
    }
}
