using System;
using UnityEngine;

namespace Character.Abilities
{
    public class CharacterShoot: MonoBehaviour
    {
        public GameObject projectilePrefab;
        public float projectileSpeed;
        public Transform spawnPosition;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject projectile = Instantiate(projectilePrefab, spawnPosition.position, Quaternion.identity);
                Vector3 projectileDirection = transform.forward;
                
                projectile.GetComponent<Rigidbody>().AddForce(projectileDirection * projectileSpeed, ForceMode.Impulse);
            }
        }
    }
}