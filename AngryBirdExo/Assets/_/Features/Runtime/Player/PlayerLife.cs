using System;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerLife : MonoBehaviour
    {
        #region Api Unity

        private void Awake()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(_layerMasks))
            {
                _isLife = false;
            }
        }

        #endregion
        
        
        #region Utils

        public bool IAmAlive()
        {
            return _isLife;
            
        }
        
        #endregion
        
        
        #region Main Methods
        
        
        
        #endregion
        
        
        #region Private And Protected
        
        // private Collider2D _collider2D;
        private bool _isLife = true;
        [SerializeField] private string _layerMasks;

        #endregion
    }
}
