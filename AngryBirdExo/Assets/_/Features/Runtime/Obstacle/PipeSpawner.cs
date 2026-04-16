using Runtime.GameManager;
using UnityEngine;
using UnityEngine.Pool;

public class PipeSpawner : MonoBehaviour
{

    #region API Unity

    private void Awake()
    {
        _pipePool = GetComponent<PipePool>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 1f, _spawnRate);
    }

    #endregion
    
    
    #region Utils

    public void StopSpawning()
    {
        CancelInvoke("SpawnPipe");
    }
    
    #endregion


    #region Main Methods (méthodes private)

    private void SpawnPipe()
    {
        if (!GameManager.Instance.IsPlaying())
            return;
    
        Vector2 spawnPosition = new Vector2(_container.transform.position.x, Random.Range(-3, 3));
        GameObject availablePipe = _pipePool.GetFirstAvailablePipe();
        availablePipe.transform.position = spawnPosition;
        availablePipe.SetActive(true);

    }

    #endregion


    #region Private and Protected

    private PipePool _pipePool;
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnRate = 2f;

    #endregion
    
}