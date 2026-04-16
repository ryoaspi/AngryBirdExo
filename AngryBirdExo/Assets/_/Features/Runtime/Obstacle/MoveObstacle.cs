using System;
using Runtime.GameManager;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    #region Publics

    public float m_speed = 1.0f;

    #endregion


    #region API Unity

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying())
            return;

        transform.Translate(Vector3.left * (m_speed * Time.deltaTime));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("End"))
        {
            gameObject.SetActive(false);
        }
    }

    #endregion
    
}