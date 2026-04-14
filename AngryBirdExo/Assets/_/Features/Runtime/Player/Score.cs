using System;
using TMPro;
using UnityEngine;

namespace Runtime.Player
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        private int _score;


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Point"))
            {
                _score++;
                _scoreText.text = "Score: " + _score;
            }
        }
    }
}
