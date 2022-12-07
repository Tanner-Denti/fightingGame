using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    // a variable vector for the location that a player will spawn
    public Vector3 spawnLocation = new Vector3(0,0,0);

    // Get the Health.cs script
    [SerializeField] Health Health;

    // The amount of times a players health can get to or below 0
    public int Lives = 3;
   
    void Update()
    {
        // If the Player gets less than or equal to 0 lives the player game object will be deleted
        Respawn();
        if( Lives <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
        {
            
            // If the player enters this there health will equal 0
            if (other.gameObject.CompareTag("Border"))
            {
                Health.health = 0;
            }
        }
    
    // If the players health is less than or equal to 0 the player will spawn at the location specified earlier
    // There health will be reset
    private void Respawn()
    {

        if(Health?.health <= 0)
        {
            transform.position = spawnLocation;
            Lives -= 1;
            Health.health = Health.MAX_HEALTH;
        }
    }

    // The Players game object gets deleted
    private void Die()
    {
        Debug.Log("I am Dead");
        Destroy(gameObject);
    }
    
    
    // Make another method for respawning when the player health equals zero.
}
