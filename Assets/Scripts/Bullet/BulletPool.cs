using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;

    private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>(_bullet, _container);
    }

    public Bullet GetBullet()
    {
        Bullet bullet = _bulletPool.GetObject();
        bullet.Hit += PutBullet;

        return bullet;
    }

    public void PutBullet(Bullet bullet)
    {
        _bulletPool.PutObject(bullet);
        bullet.Hit -= PutBullet;
    }

    public void Reset()
    {
        _bulletPool.Reset();
    }
}