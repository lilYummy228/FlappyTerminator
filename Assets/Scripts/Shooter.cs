using System.Collections;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected Transform _shotPoint;

    private BulletPool _bulletPool;
    private float _rotationZ;
    private float _rotationY;

    public BulletPool BulletPool => _bulletPool;
    public float RemoveDistance => 15f;

    private void OnEnable()
    {
        _bulletPool = GameObject.Find("BulletContainer").GetComponent<BulletPool>();
    }

    public virtual void TakeBullet(Transform shotPoint, Vector2 direction)
    {
        _rotationZ = transform.rotation.eulerAngles.z;
        _rotationY = transform.rotation.eulerAngles.y;

        Bullet bullet = _bulletPool.GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = shotPoint.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0, _rotationY, _rotationZ);

        StartCoroutine(SetBulletDirection(bullet, direction));
    }

    public virtual IEnumerator SetBulletDirection(Bullet bullet, Vector2 direction)
    {
        Vector3 targetPoint = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * direction;

        while (bullet.isActiveAndEnabled)
        {
            bullet.transform.position += targetPoint * _speed * Time.deltaTime;
            yield return null;
        }
    }
}
