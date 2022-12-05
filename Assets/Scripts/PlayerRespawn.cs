using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Vector3 spawnLocation = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
        {
            // TODO:
            //  Change so this affect the player health
            if (other.gameObject.CompareTag("Border"))
            {
               transform.position = spawnLocation;

            }
        }
    
    // Make another method for respawning when the player health equals zero.
}
