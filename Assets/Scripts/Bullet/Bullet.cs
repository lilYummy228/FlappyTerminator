using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    public event Action<Bullet> Hit;
    private ScoreCounter _scoreCounter;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _scoreCounter = GameObject.FindObjectOfType<ScoreCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interectable))
        {
            if (interectable is Enemy)
                _scoreCounter.Add();

            Hit?.Invoke(this);
        }
    }
}
