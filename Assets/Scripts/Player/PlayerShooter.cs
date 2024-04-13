using System.Collections;
using UnityEngine;

public class PlayerShooter : Shooter
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale == 1)
            TakeBullet(Vector3.right);
    }

    public override IEnumerator SetBulletDirection(Bullet bullet)
    {
        while (bullet.transform.position.x - transform.position.x <= RemoveDistance)
        {
            bullet.transform.position += Vector3.right * Speed * Time.deltaTime;
            yield return null;
        }

        BulletPool.PutBullet(bullet);
    }
}
