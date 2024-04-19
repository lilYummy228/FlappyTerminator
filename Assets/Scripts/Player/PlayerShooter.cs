using UnityEngine;

public class PlayerShooter : Shooter
{
    private float _nextAttackTime = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale == 1)
        {
            if (Time.time >= _nextAttackTime)
            {
                TakeBullet(_shotPoint, Vector2.right);

                _nextAttackTime = Time.time + _delay;
            }
        }
    }
}
