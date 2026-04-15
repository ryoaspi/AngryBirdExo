using UnityEngine;

public class SizeAdaptor : MonoBehaviour
{


    private void Awake()
    {
        float _screenWidth = Camera.main.orthographicSize * _offset * Screen.width / Screen.height;
        float _screenHeight = Camera.main.orthographicSize * _offset * Screen.height / Screen.width;
        
        transform.localScale = new Vector3(_screenWidth, transform.localScale.y, transform.localScale.z);

        if (_leftBorder)
        {
            transform.position = new Vector3(-_screenWidth/2, 0, 0);
            transform.localScale = new Vector3(_screenHeight + _offetY, transform.localScale.y, transform.localScale.z);
        }
    }
    
    [SerializeField] private float _offset = 2.0f;
    [SerializeField] private bool _leftBorder; 
    [SerializeField] private float _offetY = 2.0f;
}
