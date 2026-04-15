using Runtime.GameManager;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerLife : MonoBehaviour
    {
        
        #region Api Unity

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _score = FindFirstObjectByType<ScoreManager>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_layerMasks))
            {
                _isAlive = false;
                gameObject.SetActive(false);
                UpdatePhysicsState();
                
                GameManager.GameManager.Instance.SetGameOver(_score.m_currentScore);
            }
        }

        #endregion
        
        
        #region Utils

        public bool IAmAlive()
        {
            return _isAlive;
        }
        public void UpdatePhysicsState()
        {
            _rb.simulated = IAmAlive();
        }
        
        #endregion
        
        
        #region Private And Protected
        
        private bool _isAlive = true;
        [SerializeField] private string _layerMasks;
        [SerializeField] private string _layerPoint;
        private Rigidbody2D _rb;
        private ScoreManager _score;

        #endregion
    }
}
