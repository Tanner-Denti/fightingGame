using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneAttack : MonoBehaviour
{
    public GameObject attackArea = default;

    public bool attacking = false;

    public float timeToAttack = 0.25f;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

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
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}