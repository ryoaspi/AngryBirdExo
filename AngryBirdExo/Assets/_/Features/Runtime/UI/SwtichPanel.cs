using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI
{
    public class SwtichPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _title;
        [SerializeField] private GameObject _SelectedAvatar;
        [SerializeField] private CanvasGroup _imageSettings;
        
        [SerializeField] private float _timeSwitch = 5f;

        private void Awake()
        {
            if (!_title)
            {
                Debug.LogWarning("SwtichPanel: _title is null");
            }

            if (!_SelectedAvatar)
            {
                Debug.LogWarning("SwtichPanel: _SelectedAvatar is null");
            }
            
            if (_imageSettings == null)
            {
                Debug.LogError("SwtichPanel: _imageSettings is NULL → assign in inspector");
                return;
            }
            
            _title.SetActive(true);
            _SelectedAvatar.SetActive(false);
            _imageSettings.alpha = 0f;
        }


        private void Update()
        {
            _timeSwitch -= Time.deltaTime;

            if (_timeSwitch > 0f)
            {
                // Fade IN
                _imageSettings.alpha += Time.deltaTime/_timeSwitch;
            }
            else
            {
                // Switch une seule fois
                if (_title.activeSelf)
                {
                    _title.SetActive(false);
                    _SelectedAvatar.SetActive(true);
                }

                // Fade OUT
                _imageSettings.alpha -= Time.deltaTime;
            }

            // Clamp pour éviter les valeurs absurdes
            _imageSettings.alpha = Mathf.Clamp01(_imageSettings.alpha);
        }
    }
}
