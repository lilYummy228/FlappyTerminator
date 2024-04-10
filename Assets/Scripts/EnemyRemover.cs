using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _enemyPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Obstacle obstacle) && other.TryGetComponent(out CollisionHandler collisionHandler))
            _enemyPool.PutObject(obstacle);
    }
}
