using GachiBird.Input;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

namespace GachiBird.PlayerLogic
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        
        [Header("Jumping")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _defaultGravityScale;
        
        [Header("Moving")]
        [SerializeField] private float _defaultSpeed;
        [SerializeField] private Vector2 _defaultDirection;
        
        private bool _isDead;
        
        public event Action OnJump;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _isDead = false;
            
            SetControls();
            
            _gameCycle.OnGameStart += () => ChangeGravityScale(_defaultGravityScale);
            _gameCycle.OnGameEnd += DisableControls;
        }
        private void Start()
        {
            ChangeGravityScale(0);
            
            MoveTo(_defaultDirection, _defaultSpeed);
        }
        
        private void OnEnable()
        {
            EnableControls();
        }
        private void OnDisable()
        {
            DisableControls();
        }
        private void OnDestroy()
        {
            UnsetControls();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            TryToDie();
        }
        
        public void ChangeJumpForce(float jumpForce)
        {
            if (jumpForce < 0)
            {
                throw new ArgumentException();
            }
            
            _jumpForce = jumpForce;
        }
        private void ChangeGravityScale(float gravityScale)
        {
            if (gravityScale < 0)
            {
                throw new ArgumentException();
            }
            
            _rigidbody.gravityScale = gravityScale;
        }
        public void ChangeMoveSpeed(float speed)
        {
            if (speed < 0)
            {
                throw new ArgumentException();
            }
            
            MoveTo(_defaultDirection, speed);
        }
        
        private void TryToDie()
        {
            if (_isDead)
            {
                return;
            } 

            _isDead = true;
            _gameCycle.EndGame();    
            
        }
        private void Jump(InputAction.CallbackContext context)
        {
            OnJump?.Invoke();
            
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
        private void MoveTo(Vector2 direction, float speed)
        {
            if (speed < 0)
            {
                throw new ArgumentException();
            }
            
            _rigidbody.velocity = new Vector2(direction.normalized.x * speed, _rigidbody.velocity.y);
        }
        
        private void SetControls()
        {
            GeneralInput.Controls.Player.Jump.performed += Jump;
        }
        private void UnsetControls()
        {
            GeneralInput.Controls.Player.Jump.performed -= Jump;
        }

        private void EnableControls()
        {
            GeneralInput.Controls.Player.Enable();
        }
        private void DisableControls()
        {
            GeneralInput.Controls.Player.Disable();
        }
    }
}
