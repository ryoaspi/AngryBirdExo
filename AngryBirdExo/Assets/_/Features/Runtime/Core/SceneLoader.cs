using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.GameManager
{
    public class SceneLoader : MonoBehaviour
    {
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        public void LoadSceneByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }
        
        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
}
