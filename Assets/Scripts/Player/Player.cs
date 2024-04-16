using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerShooter), typeof(ScoreCounter))]
public class Player : Character, IInteractable
{
    private PlayerMover _playerMover;
    private ScoreCounter _scoreCounter;
    private PlayerShooter _playerShooter;

    public event Action GameOver;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _playerShooter = GetComponent<PlayerShooter>();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _playerMover.Reset();
    }

    protected override void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Enemy || interactable is Ground || interactable is Bullet)
            GameOver?.Invoke();
        else if (interactable is ScoreZone)
            _scoreCounter.Add();
    }
}
