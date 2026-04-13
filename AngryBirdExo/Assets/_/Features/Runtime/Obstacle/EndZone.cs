using UnityEngine;

public class EndZone : MonoBehaviour
{
    #region Api Unity

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Contact");
        if (other.gameObject.layer == LayerMask.NameToLayer(_layer))
        {
            Debug.Log(other.gameObject.name + " Touch ");
            
            Destroy(other.gameObject);
        }
    }

    #endregion
    
    
    #region Private and Protected

    [SerializeField] private string _layer;

    #endregion
}
