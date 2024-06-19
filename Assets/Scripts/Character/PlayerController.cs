using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        public bool playerAuthorized = true;
        public float speed = 350f;
        private Rigidbody _rb;
        [SerializeField] private Animator animator;

        private bool _isMoving = false;
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int GameOver = Animator.StringToHash("GameOver");

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }
        }

        public void FreezePlayer()
        {
            playerAuthorized = false;
        }

        public void UnfreezePlayer()
        {
            playerAuthorized = true;
        }

        public void PlayGameOverAnimation()
        {
            _isMoving = false;
            animator.SetBool(IsMoving, _isMoving);
            _rb.velocity = Vector3.zero;
            animator.SetBool(GameOver, true);
        }

        private void FixedUpdate()
        {
            if (!playerAuthorized) return;
            
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new(horizontal * speed, _rb.velocity.y, 0.0f);
            _rb.velocity = moveDirection;
            
            _isMoving = _rb.velocity.magnitude != 0;
            
            animator.SetBool(IsMoving, _isMoving);
            animator.SetFloat(Horizontal, horizontal);
        }

        public void PlayAnimationTrigger(string value)
        {
            animator.SetTrigger(value);
        }
    }
}