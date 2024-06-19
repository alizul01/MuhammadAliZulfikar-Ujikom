using Character.Abilities;
using UnityEngine;

namespace Weapon
{
    public class Projectile : MonoBehaviour
    {
        public float attack;
        public float maxTime;

        private float currentTime = 0.0f;

        private void Update()
        {
            if (currentTime < maxTime)
                currentTime += Time.deltaTime;

            if (currentTime >= maxTime)
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