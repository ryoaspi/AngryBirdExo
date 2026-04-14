using UnityEngine;

namespace Runtime.GameManager
{
    public class GameManager : MonoBehaviour
    {
        #region Publics
        
        public static GameManager Instance;
        public GameObject m_gameOver;
        public enum GameState
        {
            Playing, 
            GameOver
        }
        
        public GameState m_currentState = GameState.Playing;
        
        #endregion
        

        #region Api Unity
        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            else
            {
                Destroy(gameObject);
            }
            
            m_gameOver.SetActive(false);
        }
        
        #endregion
        
        
        #region Utils

        public bool IsPlaying()
        {
            return m_currentState == GameState.Playing;
        }

        public void SetGameOver()
        {
            m_currentState = GameState.GameOver;
            m_gameOver.SetActive(true);
        }
        
        #endregion
    }
}
