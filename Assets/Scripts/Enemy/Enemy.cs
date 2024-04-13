using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : Character, IInteractable
{
    [SerializeField] private ScoreCounter _scoreCounter;

    public EnemyShooter EnemyShooter { get; private set; }

    public event Action<Enemy> Dead;

    private void Start()
    {
        EnemyShooter = GetComponent<EnemyShooter>();
    }

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Bullet)
        {
            _scoreCounter.Add();
            Dead?.Invoke(this);
        }
    }
}
