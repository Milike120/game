using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealthBar : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    public float HeroHealth = 100f;

    public void ApplyHeroDamage(float damage)
    {
        HeroHealth -= damage;
        if (HeroHealth <= 0)
        {
            healthBar.setSize(0);
        }
    }

    void Update()
    {
        float health;
        if (HeroHealth > 0)
        {
            health = HeroHealth / 100;
            healthBar.setSize(health);
        }
    }
}