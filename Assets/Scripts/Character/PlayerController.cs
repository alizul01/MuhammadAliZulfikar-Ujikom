using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 350f;
        private Rigidbody _rb;
        [SerializeField] private Animator animator;

        private bool _isMoving = false;
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }
        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new Vector3(horizontal * speed, _rb.velocity.y, 0.0f);
            _rb.velocity = moveDirection;

            animator.SetFloat(Horizontal, horizontal);
        }
    }
}