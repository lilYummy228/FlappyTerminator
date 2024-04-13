using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(PlayerShooter), typeof(ScoreCounter))]
public class Player : Character, IInteractable
{
    private Mover _mover;
    private ScoreCounter _scoreCounter;
    private PlayerShooter _playerShooter;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _playerShooter = GetComponent<PlayerShooter>();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Enemy || interactable is Ground || interactable is Bullet)
            GameOver?.Invoke();
        else if (interactable is ScoreZone)
            _scoreCounter.Add();
    }
}
