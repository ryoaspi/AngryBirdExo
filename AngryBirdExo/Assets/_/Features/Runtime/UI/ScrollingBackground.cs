using UnityEngine;

namespace Runtime.UI
{
    public class ScrollingBackground : MonoBehaviour
    {
        [SerializeField] private Material _material;

        [SerializeField] private float _speed = 1f;
        // Update is called once per frame
        void Update()
        {
            Vector2 offset = _material.mainTextureOffset;
            offset.x += Time.deltaTime * _speed;
            _material.mainTextureOffset = offset;
        }
    }
}
