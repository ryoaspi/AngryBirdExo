using Runtime.GameManager;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    #region Publics

    public float m_speed = 1.0f;

    #endregion


    #region API Unity

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying())
            return;

        transform.Translate(Vector3.left * (m_speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("End"))
        {
            _spawner.ReleasePipe(gameObject);
        }
    }

    #endregion


    #region Utils (méthodes publics)

    public void Init(PipeSpawner spawner)
    {
        _spawner = spawner;
    }

    #endregion


    #region Private and Protected

    private PipeSpawner _spawner;

    #endregion
}