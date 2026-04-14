using Runtime.GameManager;
using UnityEngine;
using UnityEngine.Pool;

public class PipeSpawner : MonoBehaviour
{
    #region Publics
    
    public GameObject m_pipePrefab;
    public float m_spawnRate = 2f;
    
    #endregion
    
    
    #region Api Unity
    
    private void Start()
    {
        InvokeRepeating("SpawnPipe", 1f, m_spawnRate);
    }

    #endregion

    
    #region Main Methods
    
    void SpawnPipe()
    {
        if (!GameManager.Instance.IsPlaying())
            return;
        
        float randomY = Random.Range(-2f, 2f);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        
        Instantiate(m_pipePrefab, spawnPos, Quaternion.identity);
    }
    
    #endregion
    
    
    #region Private and Protected
    
    private PooledObject<GameObject> _pooledObject;
    
    #endregion
}
