using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 350f;
        private CharacterController _characterController;
        [SerializeField] private Animator animator;

        private bool _isMoving = false;
        private static readonly int Speed = Animator.StringToHash("Horizontal");

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }
        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal != 0)
            {
                _isMoving = true;
                
                Vector3 moveDirection = new Vector3(horizontal, 0.0f, 0.0f).normalized * (speed * Time.deltaTime);
                _characterController.Move(moveDirection);
                animator.SetFloat(Speed, horizontal);
            }
            else
            {
                _isMoving = false;
            }
        }
    }
}
