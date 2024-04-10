using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(CollisionHandler), typeof(ScoreCounter))]
public class Player : MonoBehaviour
{
    private Mover _mover;
    private CollisionHandler _collisionHandler;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Obstacle)
            GameOver?.Invoke();

        if (interactable is ScoreZone)
            _scoreCounter.Add();
    }    
}
