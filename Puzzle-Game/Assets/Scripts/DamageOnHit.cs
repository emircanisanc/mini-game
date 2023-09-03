using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.ApplyDamage();
        }    
    }
}
