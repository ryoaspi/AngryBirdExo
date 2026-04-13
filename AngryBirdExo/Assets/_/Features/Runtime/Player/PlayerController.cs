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


        #endregion
        
        
        #region Utils
        
        public void OnMove(InputAction.CallbackContext context)
        {
            context.ReadValueAsButton();
            if (context.started && _playerLife.IAmAlive()== true)
            {
                _rb.AddRelativeForceY(_jumping);
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
        [SerializeField] private float _jumping = 0.5f;
        private Rigidbody2D _rb;
        private PlayerLife _playerLife;

        #endregion
    }
}
