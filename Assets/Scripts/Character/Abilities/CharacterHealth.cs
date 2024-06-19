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

        public ParticleSystem onHitVfx;

        private Action onEnemyDeath;
        
        [Header("Audio")] private AudioSource _audioSource;
        public AudioClip onHitSfx;
        public AudioClip onDeathSfx;

        private void Awake()
        {
            healthSlider.minValue = currentHealth;
            healthSlider.maxValue = maximumHealth;
            _audioSource = GetComponent<AudioSource>();
        }

        public void Hit(float value)
        {
            _audioSource.PlayOneShot(onHitSfx);
            healthSlider.value = Mathf.MoveTowards(currentHealth, value, Time.deltaTime);
            currentHealth += value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maximumHealth);
            onHitVfx.Play();
            if (currentHealth >= maximumHealth)
            {
                _audioSource.PlayOneShot(onDeathSfx);
                Die();
            }
        }

        private void Die()
        {
            ScoreManager.Instance.AddScore(enemyReward);
            gameObject.SetActive(false);
            Destroy(gameObject, onDeathSfx.length + 1);
        }
    }
}