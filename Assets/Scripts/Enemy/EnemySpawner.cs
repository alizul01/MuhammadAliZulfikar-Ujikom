using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<Enemy> enemies;
        private Collider _spawnArea;
        public float spawnInterval = 2.5f;

        private float _timeSinceLastSpawn = 0.0f;

        private void Awake()
        {
            _spawnArea = GetComponent<Collider>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_timeSinceLastSpawn >= spawnInterval)
            {
                _timeSinceLastSpawn = 0.0f;
                Spawn();
            }

            _timeSinceLastSpawn += Time.deltaTime;
        }

        private void Spawn()
        {
            int randomIndex = Random.Range(0, enemies.Count);
            
            Vector3 spawnPos = GetPosition();
            GameObject enemy = enemies[randomIndex].gameObject;
            Instantiate(enemy, spawnPos, Quaternion.Euler(0, 180, 0));
        }

        private Vector3 GetPosition()
        {
            Bounds bounds = _spawnArea.bounds;
            float randomPositionXVector3 = Random.Range(bounds.min.x, bounds.max.x);
            Vector3 randomPos = new(randomPositionXVector3, 0, _spawnArea.transform.position.z);
            return randomPos;
        }
    }
}
