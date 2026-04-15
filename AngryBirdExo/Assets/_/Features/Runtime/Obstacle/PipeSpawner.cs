using Runtime.GameManager;
using UnityEngine;
using UnityEngine.Pool;

public class PipeSpawner : MonoBehaviour
{
    #region Publics

    public GameObject m_pipePrefab;
    public float m_spawnRate = 2f;
    public int m_initialPoolSize = 10;
    public int m_maxPoolSize = 20;

    #endregion


    #region API Unity

    private void Awake()
    {
        InitPool();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1f, m_spawnRate);
    }

    #endregion


    #region Utils (méthodes publics)

    public void ReleasePipe(GameObject pipe)
    {
        _pool.Release(pipe);
    }

    #endregion


    #region Main Methods (méthodes private)

    private void SpawnPipe()
    {
        if (!GameManager.Instance.IsPlaying())
            return;

        float randomY = Random.Range(-2f, 2f);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);

        GameObject pipe = _pool.Get();
        pipe.transform.position = spawnPos;
        pipe.transform.rotation = Quaternion.identity;
    }

    private void InitPool()
    {
        _pool = new ObjectPool<GameObject>(
            CreatePipe,
            OnGetPipe,
            OnReleasePipe,
            OnDestroyPipe,
            false,
            m_initialPoolSize,
            m_maxPoolSize
        );
    }

    private GameObject CreatePipe()
    {
        GameObject obj = Instantiate(m_pipePrefab, _container.transform);
        return obj;
    }

    private void OnGetPipe(GameObject obj)
    {
        obj.SetActive(true);
        
        MoveObstacle pipe = obj.GetComponent<MoveObstacle>();
        pipe.Init(this);
    }

    private void OnReleasePipe(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyPipe(GameObject obj)
    {
        Destroy(obj);
    }

    #endregion


    #region Private and Protected

    private ObjectPool<GameObject> _pool;
    [SerializeField] private GameObject _container;

    #endregion
    
}