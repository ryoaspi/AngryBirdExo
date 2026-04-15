using System;
using UnityEngine;

namespace Runtime.GameManager
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _playerPrefabs;
        [SerializeField] private Transform _spawnPoint;

        private void Start()
        {
            int index = PlayerDataManager.Instance.m_selectedAvatarIndex;
            
            if (index < 0 || index >= _playerPrefabs.Length)
                index = 0;
            
            Instantiate(_playerPrefabs[index], _spawnPoint.position, Quaternion.identity);
        }
    }
}
