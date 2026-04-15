using UnityEngine;

namespace Runtime.GameManager
{
    public class ScoreZone : MonoBehaviour
    {
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                FindFirstObjectByType<ScoreManager>().AddPoint();
            }
        }
    }
}
