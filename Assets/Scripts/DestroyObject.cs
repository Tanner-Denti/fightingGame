using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DestroyObject : MonoBehaviour
    {
        Spawner spawner;
        private bool shouldDestroy = true;
        
        void awake()
        {
            spawner = spawner.GetComponent<Spawner>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                shouldDestroy = false;
            }
            if(shouldDestroy == true)
            {
                Destroy(other.gameObject, 7f);
            }
            shouldDestroy = true;
        }
        
        
    }
}