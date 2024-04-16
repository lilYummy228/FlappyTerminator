using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemyPool _enemyPool;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);

        StartCoroutine(nameof(GenerateEnemy));
    }

    private IEnumerator GenerateEnemy()
    {
        while (enabled)
        {
            Spawn();
            yield return _wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        Enemy enemy = _enemyPool.GetEnemy();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;

        enemy.EnemyShooter.StartShooting();
    }
}
