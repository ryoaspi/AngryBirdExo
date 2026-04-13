using System;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerLife : MonoBehaviour
    {
        
        #region Api Unity

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
        
        
        #region Private And Protected
        
        private bool _isLife = true;
        [SerializeField] private string _layerMasks;

        #endregion
    }
}
