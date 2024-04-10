using System.Collections;
using UnityEngine;

public class EnemyShooter : Shooter
{
    [SerializeField] private float _delay;

    private Quaternion _rotation;
    private float _rotationValue = 180;

    private void Start()
    {
        _rotation = Quaternion.Euler(0, _rotationValue, 0);

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            TakeBullet(Vector3.left);

            yield return wait;
        }
    }

    public override IEnumerator SetBulletDirection(Obstacle bullet)
    {
        while (bullet.transform.position.x - transform.position.x >= -RemoveDistance)
        {
            bullet.transform.Translate(Vector3.left * Speed * Time.deltaTime);
            yield return null;
        }

        BulletPool.PutObject(bullet);
    }
}
