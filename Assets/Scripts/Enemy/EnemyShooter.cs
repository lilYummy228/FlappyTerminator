using System.Collections;
using UnityEngine;

public class EnemyShooter : Shooter
{
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            TakeBullet(_shotPoint, Vector2.left);
            yield return _wait;
        }
    }

    public void StartShooting()
    {
        StartCoroutine(nameof(Shoot));
    }
}
