using System;
using UnityEngine;

namespace Character.Abilities
{
    public class CharacterShoot: MonoBehaviour
    {
        private PlayerController _player;
        
        public GameObject projectilePrefab;
        public float projectileSpeed;
        public Transform spawnPosition;

        private static readonly int Shoot = Animator.StringToHash("Shoot");

        private void Start()
        {
            _player = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (!_player.playerAuthorized) return;
            if (Input.GetMouseButtonDown(0))
            {
                GameObject projectile = Instantiate(projectilePrefab, spawnPosition.position, Quaternion.identity);
                Vector3 projectileDirection = transform.forward;

                _player.PlayAnimationTrigger("Shoot");
                projectile.GetComponent<Rigidbody>().AddForce(projectileDirection * projectileSpeed, ForceMode.Impulse);
            }
        }
    }
}