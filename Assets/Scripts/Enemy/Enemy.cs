using System;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        public float speed;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 movementDirection = transform.forward * speed * Time.deltaTime;
            movementDirection.y = 0;
            _rb.velocity = movementDirection * speed;
        }
    }
}
