using TMPro;
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
        
        public int m_highScore;
        
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
            
            m_highScore = PlayerPrefs.GetInt(_highScoreKey, 0);
        }
        
        #endregion
        
        
        #region Utils

        public bool IsPlaying()
        {
            return m_currentState == GameState.Playing;
        }

        public void SetGameOver(int finalScore)
        {
            m_currentState = GameState.GameOver;
            
            _scoreManager.gameObject.SetActive(false);
            
            TrySaveHighScore(finalScore);
            _highScoreText.text = "Best : " + m_highScore;
            
            m_gameOver.SetActive(true);
        }

        public void TrySaveHighScore(int currentScore)
        {
            if (currentScore > m_highScore)
            {
                m_highScore = currentScore;
                PlayerPrefs.SetInt(_highScoreKey, m_highScore);
                PlayerPrefs.Save();
            }

        }
        
        #endregion
        
        
        #region Private and Protected
        
        private const string _highScoreKey = "HighScore";
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private ScoreManager _scoreManager;
        
        #endregion
    }
}
