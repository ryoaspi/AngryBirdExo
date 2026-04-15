using TMPro;
using UnityEngine;

namespace Runtime.GameManager
{
    public class ScoreManager : MonoBehaviour
    {
        public TMP_Text m_scoreText;
        public int m_currentScore;
        
        private void Start()
        {
            UpdateScore();
        }
        public void AddPoint()
        {
            m_currentScore++;
            UpdateScore();
        }

        public void UpdateScore()
        {
            m_scoreText.text = "Score: " + m_currentScore;
        }
            
            

    }
}
