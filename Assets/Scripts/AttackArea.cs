using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 25;
    // private int defDamage = 0;
    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.GetComponent<Health>();

        if (collider.GetComponent<PlayerOneAttack>().Defending)
        //  || collider.GetComponent<PlayerTwoAttack>().PlayerTwoDefending)
        {
            damage = 0;
        //    return;
        }
        else {
            damage = 25;
        }

        if (collider.GetComponent<Health>() != null)
        {
            // Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
