using Runtime.GameManager;
using UnityEngine;

namespace Runtime.UI
{
    public class AvatarSelectedUI : MonoBehaviour
    {
        public void SelectAvatar(int index)
        {
            PlayerDataManager.Instance.m_selectedAvatarIndex =  index;
        }
    }
}
