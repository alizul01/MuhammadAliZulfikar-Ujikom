using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Abilities
{
    public class CharacterHealth: MonoBehaviour
    {
        public int enemyReward;
        
        public float currentHealth;
        public float maximumHealth;
        public Slider healthSlider;

        private Action onEnemyDeath;

        private void Awake()
        {
            healthSlider.minValue = currentHealth;
            healthSlider.maxValue = maximumHealth;
        }

        private void Start()
        {
        }

        public void Hit(float value)
        {
            healthSlider.value = Mathf.MoveTowards(currentHealth, value, Time.deltaTime);
            currentHealth += value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maximumHealth);
            if (currentHealth >= maximumHealth)
            {
                Die();
            }
        }

        private void Die()
        {
            ScoreManager.Instance.AddScore(enemyReward);
            Destroy(gameObject);
        }
    }
}