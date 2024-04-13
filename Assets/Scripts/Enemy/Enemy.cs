using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : Character, IInteractable
{
    public event Action<Enemy> Dead;

    private EnemyShooter _enemyShooter;

    private void Start()
    {
        _enemyShooter = GetComponent<EnemyShooter>();
    }

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Player || interactable is Bullet)
            Dead?.Invoke(this);
    }
}
