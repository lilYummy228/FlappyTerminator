using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Obstacle _prefab;
    [SerializeField] private Transform _container;

    private Queue<Obstacle> _pool;

    private void Awake()
    {
        _pool = new Queue<Obstacle>();
    }

    public Obstacle GetObject()
    {
        if (_pool.Count == 0)
        {
            var obstacle = Instantiate(_prefab);
            obstacle.transform.parent = _container;

            return obstacle;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Obstacle obstacle)
    {
        _pool.Enqueue(obstacle);
        obstacle.gameObject.SetActive(false);
    }

    public void Reset()
    {
        foreach (Transform child in _container)
            if (child.TryGetComponent(out Obstacle obstacle))
                PutObject(obstacle);
    }
}
