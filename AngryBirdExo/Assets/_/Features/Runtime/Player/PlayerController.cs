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
            DebugInfo();
        }

        private void Update()
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, Mathf.Clamp(_rb.linearVelocity.y, -10f, 10f));
            
        }

        #endregion
        
        
        #region Utils
        
        public void OnJumping(InputAction.CallbackContext context)
        {
            context.ReadValueAsButton();
            if (context.started && _playerLife.IAmAlive())
            {
                _rb.linearVelocity = Vector2.zero;
                _rb.AddForce(Vector2.up * _jumping, ForceMode2D.Impulse);
            }
        }


        
        #endregion
        
        
        #region Main Methods
        
        private void DebugInfo()
        {
            if (_rb == null)
            {
                Debug.LogError($"PlayerController: Rigidbody was not found on {gameObject.name}");
            }

            if (_playerLife == null)
            {
                Debug.LogError($"PlayerController: PlayerLife was not found on {gameObject.name}");
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

        #endregion
    }
}
