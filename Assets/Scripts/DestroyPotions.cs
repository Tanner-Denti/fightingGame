using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DestroyPotions : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            
            if (collision.gameObject.CompareTag("berserkPotion"))
            {
                Destroy(GameObject.FindWithTag("berserkPotion"));
            }
            if (collision.gameObject.CompareTag("fastPotion"))
            {
                Destroy(GameObject.FindWithTag("fastPotion"));
            }
            if (collision.gameObject.CompareTag("jumpPotion"))
            {
                Destroy(GameObject.FindWithTag("jumpPotion"));
            }
            if (collision.gameObject.CompareTag("healthPotion"))
            {
                Destroy(GameObject.FindWithTag("healthPotion"));
            }

        
        }
        
        
    }
}
