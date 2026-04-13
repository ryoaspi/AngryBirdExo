using System;
using Runtime.Player;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    #region Publics
    
    public float m_speed = 1.0f;
    
    #endregion
    
    
    #region Api Unity

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Contact");

        if (other.gameObject.layer == LayerMask.NameToLayer("End"))
        {
            Debug.Log(other.gameObject.name + " Touch ");

            gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (m_player.IAmAlive()) transform.Translate(Vector3.left * (m_speed * Time.deltaTime));
    }
    
    #endregion
    
    
    #region Private and Protected
    
    [SerializeField] private PlayerLife m_player;

    #endregion
}
