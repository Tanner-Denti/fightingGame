using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] potions;
    public GameObject[] weapons;
    public float powerup_minTime = 15;
    public float powerup_maxTime = 30;
    public float weapon_minTime = 30;
    public float weapon_maxTime = 60;
    private bool spawnpowerup;
    private bool spawnweapon;
    private bool destroyspawn;

    void Start()
    {
        
        foreach (GameObject weapon in  weapons)
        {
            if(weapon.GetComponent<Rigidbody>() == null)
            {
                weapon.AddComponent<Rigidbody>();
                
            }
            if(weapon.GetComponent<BoxCollider>() == null)
            {
                weapon.AddComponent<BoxCollider>();
            }
         
        }

        foreach (GameObject potion in  potions)
        {
            if(potion.GetComponent<Rigidbody>() == null)
            {
                potion.AddComponent<Rigidbody>();
            }
            if(potion.GetComponent<BoxCollider>() == null)
            {
                potion.AddComponent<BoxCollider>();
            }
        }

    }

    void Update()
    {
        if (!spawnpowerup)
        {
            float powerup_timer = Random.Range(powerup_minTime, powerup_maxTime);
    
            Invoke("MakePowerUp", powerup_timer);
 
            spawnpowerup = true;
        }

        if (!spawnweapon)
        {
       
            float weapon_timer = Random.Range(weapon_minTime, weapon_maxTime);
            Invoke("MakeWeapon", weapon_timer);


            spawnweapon = true;
        }
    }


    private void MakePowerUp()
    {
        int randomIndex = Random.Range(0, potions.Length);
        Vector3 randomPosition = new Vector3(Random.Range(-10,11), Random.Range(15,16), 0);

        Instantiate(potions[randomIndex], randomPosition, Quaternion.identity);
        

        spawnpowerup = false;
    }

    private void MakeWeapon()
    {
        int randomIndex = Random.Range(0, weapons.Length);
        Vector3 randomPosition = new Vector3(Random.Range(-10, 11), Random.Range(15, 16), 0);

        Instantiate(weapons[randomIndex], randomPosition, Quaternion.identity);

       
        spawnweapon = false;
    }


}