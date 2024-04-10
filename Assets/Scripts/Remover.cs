using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Obstacle obstacle) && other.TryGetComponent(out CollisionHandler collisionHandler))
            _pool.PutObject(obstacle);
    }
}
