using System.Collections;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _speed;

    protected BulletPool BulletPool => _bulletPool;
    protected float Speed => _speed;

    public float RemoveDistance { get; private set; } = 15f;

    public virtual void TakeBullet(Vector3 offset)
    {
        Bullet bullet = BulletPool.GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position + offset;

        StartCoroutine(SetBulletDirection(bullet));
    }

    public abstract IEnumerator SetBulletDirection(Bullet bullet);
}
