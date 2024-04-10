using System.Collections;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private float _speed;

    protected ObjectPool Pool => _pool;
    protected float Speed => _speed;

    public float RemoveDistance { get; private set; } = 15f;

    public virtual void TakeBullet(Vector3 offset)
    {
        Obstacle bullet = Pool.GetObject();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position + offset;

        StartCoroutine(SetBulletDirection(bullet));
    }

    public abstract IEnumerator SetBulletDirection(Obstacle bullet);
}
