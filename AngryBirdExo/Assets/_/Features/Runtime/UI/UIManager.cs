using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        private void Start()
        {
            
#if UNITY_WEBGL_API

        _exitButton.SetActive(false);

#endif
            // if (Application.platform == RuntimePlatform.WebGLPlayer)
            // {
            //     _exitButton.SetActive(true);
            // }
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
        [SerializeField] private GameObject _exitButton;
    }
}
