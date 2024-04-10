using UnityEngine;

public class Bullet : Obstacle, IInteractable 
{
    [SerializeField] private ObjectPool _enemyPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _enemyPool.PutObject(enemy);
    }
}
