using Character.Abilities;
using UnityEngine;

namespace Weapon
{
    public class Projectile : MonoBehaviour
    {
        public float attack;
        public float maxTime;

        private float _currentTime = 0.0f;

        private void Update()
        {
            if (_currentTime < maxTime)
                _currentTime += Time.deltaTime;

            if (_currentTime >= maxTime)
                Destroy(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<CharacterHealth>().Hit(attack);
                Destroy(gameObject);
            }
        }
    }
}