using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 25;
    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.GetComponent<Health>();

        if (collider.GetComponent<Health>() != null)
        {
            health.Damage(damage);
        }
    }
}
