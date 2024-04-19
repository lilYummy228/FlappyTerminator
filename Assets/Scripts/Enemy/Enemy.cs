using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : Character, IInteractable
{
    [SerializeField] private EnemyShooter _enemyShooter;

    public EnemyShooter EnemyShooter => _enemyShooter;

    public event Action<Enemy> Dead;

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Bullet)
        {
            Dead?.Invoke(this);
        }
    }
}