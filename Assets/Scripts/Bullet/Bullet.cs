using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    public event Action<Bullet> Hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interectable))
            Hit?.Invoke(this);
    }
}
