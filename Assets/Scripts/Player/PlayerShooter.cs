using UnityEngine;

public class PlayerShooter : Shooter
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale == 1)
            TakeBullet(_shotPoint, Vector2.right);
    }
}
