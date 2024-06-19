using System;
using UnityEngine;

namespace Character.Abilities
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterShoot: MonoBehaviour
    {
        public GameObject projectilePrefab;
        public float projectileSpeed;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 spawnPosition = transform.position + transform.forward;
                GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
                Vector3 projectileDirection = transform.forward;
                
                _rb.AddForce(projectileDirection * projectileSpeed, ForceMode.Impulse);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Nyawa enemy berkurang");
            }
        }
    }
}