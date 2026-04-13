using System;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    #region Publics
    
    public float m_speed = 1.0f;
    
    #endregion
    
    
    #region Api Unity

    private void LateUpdate()
    {
        transform.Translate(Vector3.left * (m_speed * Time.deltaTime));
    }

    #endregion
}
