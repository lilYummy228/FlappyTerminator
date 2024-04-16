using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Remover : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            _enemyPool.PutEnemy(enemy);
        else if (other.TryGetComponent(out Bullet bullet))
            _bulletPool.PutBullet(bullet);
    }
}
