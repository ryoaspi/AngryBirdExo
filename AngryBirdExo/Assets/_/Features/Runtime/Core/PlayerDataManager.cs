using System;
using UnityEngine;

namespace Runtime.GameManager
{
    public class PlayerDataManager : MonoBehaviour
    {
        #region Publics

        public static PlayerDataManager Instance;
        
        public int m_selectedAvatarIndex = 0;
        
        #endregion
        
        
        #region Api Unity

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
