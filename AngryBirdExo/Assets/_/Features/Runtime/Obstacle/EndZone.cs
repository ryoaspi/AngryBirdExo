using UnityEngine;

public class EndZone : MonoBehaviour
{
    #region Api Unity
    
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_layer))
        {
            other.gameObject.SetActive(false);
        }
    }

    #endregion
    
    
    #region Private and Protected

    [SerializeField] private string _layer;

    #endregion
}
