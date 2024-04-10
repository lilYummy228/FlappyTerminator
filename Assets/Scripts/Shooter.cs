using System.Collections;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private ObjectPool _bulletPool;
    [SerializeField] private float _speed;

    protected ObjectPool BulletPool => _bulletPool;
    protected float Speed => _speed;

    public float RemoveDistance { get; private set; } = 15f;

    public virtual void TakeBullet(Vector3 offset)
    {
        Obstacle bullet = BulletPool.GetObject();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position + offset;

        StartCoroutine(SetBulletDirection(bullet));
    }

    public abstract IEnumerator SetBulletDirection(Obstacle bullet);
}
