using System.Collections;
using UnityEngine;

public class PlayerShooter : Shooter
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale == 1)
            TakeBullet(Vector3.right);
    }

    public override IEnumerator SetBulletDirection(Obstacle obstacle)
    {
        while (obstacle.transform.position.x - transform.position.x <= RemoveDistance)
        {
            obstacle.transform.position += Vector3.right * Speed * Time.deltaTime;
            yield return null;
        }

        Pool.PutObject(obstacle);
    }
}
