using System;
using UnityEngine;

namespace Runtime.GameManager
{
    public class ScoreZone : MonoBehaviour
    {
        private void Awake()
        {
            _scoreManager = FindFirstObjectByType<ScoreManager>();

            if (_scoreManager == null)
            {
                Debug.LogError("ScoreManager not found");
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            if (_scoreManager )
            {
                _scoreManager.AddPoint();
            }
        }
        
        
        private ScoreManager _scoreManager;
    }
}
