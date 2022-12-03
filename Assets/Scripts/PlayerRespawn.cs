using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Vector3 spawnLocation = new Vector3(0,0,0);

    [SerializeField] Health Health;
    public int Lives = 3;
   
    // Start is called before the first frame update
    void Start()
    {
        // health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Respawn();
        if( Lives <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
        {
            // TODO:
            //  Change so this affect the player health
            if (other.gameObject.CompareTag("Border"))
            {
            //    transform.position = spawnLocation;

                Health.health = 0;


            }
        }
    
    private void Respawn()
    {
        if(Health?.health <= 0)
        {
            transform.position = spawnLocation;
            Lives -= 1;
            Health.health = Health.MAX_HEALTH;
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead");
        Destroy(gameObject);
    }
    
    
    // Make another method for respawning when the player health equals zero.
}
