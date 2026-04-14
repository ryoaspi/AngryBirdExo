using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
