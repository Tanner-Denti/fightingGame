using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Spawner : MonoBehaviour
    {
        private List<GameObject> potions = new List<GameObject>();
        private List<GameObject> weapons = new List<GameObject>();
        public GameObject berserkPotion;
        public GameObject fastPotion;
        public GameObject jumpPotion;
        public GameObject healthPotion;
        public GameObject bow;
        public GameObject sword;
        public GameObject shield;
        private float powerup_minTime = 15;
        private float powerup_maxTime = 30;
        private float weapon_minTime = 30;
        private float weapon_maxTime = 60;
        private bool spawnpowerup;
        private bool spawnweapon;
        private float ranges;
        


        void Start()
        {
            potions.Add(berserkPotion);
            potions.Add(fastPotion);
            potions.Add(jumpPotion);
            potions.Add(healthPotion);
            weapons.Add(bow);
            weapons.Add(shield);
            weapons.Add(sword);
            

            

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

            ranges = Random.Range(-9.00f , 10.00f);
        }


        private void MakePowerUp()
        {
            int randomIndex = Random.Range(0, potions.Count);
            Vector3 randomPosition = new Vector3(ranges, 15 , 0);

            Instantiate(potions[randomIndex], randomPosition, Quaternion.identity);
            

            spawnpowerup = false;
        }

        private void MakeWeapon()
        {
            int randomIndex = Random.Range(0, weapons.Count);
            Vector3 randomPosition = new Vector3(ranges, 15, 0);

            Instantiate(weapons[randomIndex], randomPosition, Quaternion.identity);

        
            spawnweapon = false;
        }
    }
}