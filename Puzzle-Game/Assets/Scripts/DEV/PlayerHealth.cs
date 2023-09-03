using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public Action OnDie;
    public Action OnBorn;

    public GameObject gfx;
    public GameObject dieParticle;

    bool isDead;

    public void ApplyDamage()
    {
        if (isDead)
            return;
        
        isDead = true;
        Die();
    }

    private void ResetLife()
    {
        gfx.SetActive(true);
        dieParticle.SetActive(false);
        isDead = false;
        OnBorn?.Invoke();
    }

    private void Die()
    {
        OnDie?.Invoke();
        gfx.SetActive(false);
        dieParticle.SetActive(true);
        Invoke(nameof(ResetLife), 1f);
    }
}
