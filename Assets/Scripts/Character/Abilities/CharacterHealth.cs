using System;
using UnityEngine;

namespace Character.Abilities
{
    public class CharacterHealth: MonoBehaviour
    {
        public float currentHealth;
        public float maximumHealth;

        private void Awake()
        {
            currentHealth = maximumHealth;
        }

        public void Hit(float value)
        {
            currentHealth -= value;
            currentHealth = Mathf.Clamp(currentHealth, 0, 100);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}