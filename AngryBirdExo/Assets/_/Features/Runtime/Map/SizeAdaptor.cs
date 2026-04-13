using UnityEngine;

public class SizeAdaptor : MonoBehaviour
{


    private void Update()
    {
        float _screenWidth = Camera.main.orthographicSize * _offset * Screen.width / Screen.height;
        
        transform.localScale = new Vector3(_screenWidth, transform.localScale.y, transform.localScale.z);
    }
    
    [SerializeField] private float _offset = 2.0f;

}
