using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // [SerializeField] private int health = 100;
    public int health = 100;


    // private int MAX_HEALTH = 100;
    public int MAX_HEALTH = 100;


    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        this.health -= amount;

        // if(health <= 0)
        // {
        //     Die();
        // }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health += MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("healthPotion"))
        {
            this.health += 15;   
        }
    }


    private void Die()
    {
        Debug.Log("I am Dead");
        Destroy(gameObject);
    }
}
