using UnityEngine;

namespace Runtime.Player
{
    public class PlayerLife : MonoBehaviour
    {
        
        #region Api Unity

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_layerMasks))
            {
                _isLife = false;
                UpdatePhysicsState();

                GameManager.GameManager.Instance.SetGameOver();
            }
        }

        #endregion
        
        
        #region Utils

        public bool IAmAlive()
        {
            return _isLife;
        }
        public void UpdatePhysicsState()
        {
            _rb.simulated = IAmAlive();
        }
        
        #endregion
        
        
        #region Private And Protected
        
        private bool _isLife = true;
        [SerializeField] private string _layerMasks;
        private Rigidbody2D _rb;

        #endregion
    }
}
