using TMPro;
using UnityEngine;

namespace Runtime.Player
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        public int m_currentScore;

        private void Start()
        {
            _scoreText.text = "Score: " + m_currentScore;
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Point"))
            {
                m_currentScore++;
                _scoreText.text = "Score: " + m_currentScore;
            }
        }
    }
}
