using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _container;

    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(_enemy, _container);
    }

    public Enemy GetEnemy()
    {
        Enemy enemy = _enemyPool.GetObject();
        enemy.Dead += PutEnemy;

        return enemy;
    } 

    public void PutEnemy(Enemy enemy)
    {
        _enemyPool.PutObject(enemy);
        enemy.Dead -= PutEnemy;
    }

    public void Reset()
    {
        _enemyPool.Reset();
    }
}
