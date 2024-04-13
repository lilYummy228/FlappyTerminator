using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    public event Action<Bullet> Hit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IInteractable interactable))
            Hit?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
            Hit?.Invoke(this);
    }
}
