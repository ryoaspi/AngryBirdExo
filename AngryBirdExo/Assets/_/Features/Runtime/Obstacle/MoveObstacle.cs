using Runtime.GameManager;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    #region Publics
    
    public float m_speed = 1.0f;
    
    #endregion
    
    
    #region Api Unity
    
    private void Update()
    {
        if (!GameManager.Instance.IsPlaying())
            return;
        
        transform.Translate(Vector3.left * (m_speed * Time.deltaTime));
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Contact");

        if (other.gameObject.layer == LayerMask.NameToLayer("End"))
        {
            Debug.Log(other.gameObject.name + " Touch ");

            gameObject.SetActive(false);
        }
    }
    
    #endregion
}
