using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Api Unity

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerLife = GetComponent<PlayerLife>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            DebugInfo();
            
        }

        private void Update()
        {
            if (!_playerLife.IAmAlive() || !GameManager.GameManager.Instance.IsPlaying())
                return;
            
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, Mathf.Clamp(_rb.linearVelocity.y, -10f, 10f));
        }

        #endregion
        
        
        #region Utils
        
        public void OnJumping(InputAction.CallbackContext context)
        {
            if (!context.started)
                return;

            if (_playerLife == null || !_playerLife.IAmAlive())
                return;

            if (_rb == null)
                return;

            _rb.linearVelocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _jumping, ForceMode2D.Impulse);
            
            _animator.SetTrigger("Fly");
        }
        
        #endregion
        
        
        #region Main Methods
        

        
        private void DebugInfo()
        {
            if (!_rb)
            {
                Debug.LogError($"PlayerController: Rigidbody was not found on {gameObject.name}");
            }

            if (!_playerLife)
            {
                Debug.LogError($"PlayerController: PlayerLife was not found on {gameObject.name}");
            }

            if (!_spriteRenderer)
            {
                Debug.LogError($"PlayerController: SpriteRenderer was not found on {gameObject.name}");
            }

            if (!_animator)
            {
                Debug.LogError($"PlayerController: Animator was not found on {gameObject.name}");
            }
        }

        
        #endregion
        
        
        #region Private and Protected
        
        private InputAction _inputAction;
        [Header("Bird Settings")]
        [Range(1f, 10f)]
        [SerializeField] private float _jumping = 5f;
        private Rigidbody2D _rb;
        private PlayerLife _playerLife;
        [SerializeField] private Sprite[] _sprite;
        private int _spriteIndex;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;

        #endregion
    }
}
