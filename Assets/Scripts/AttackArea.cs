using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 25;
    private void OnTriggerEnter(Collider collider)
    {
        //if (collider.GetComponent<PlayerOneAttack>().Defending || collider.GetComponent<PlayerTwoAttack>().PlayerTwoDefending)
        //{
        //    return;
        //}

        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
