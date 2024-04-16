using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public abstract class Character : MonoBehaviour, IInteractable
{
    private CollisionHandler _collisionHandler;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollisionDetected;
    }

    protected abstract void OnCollisionDetected(IInteractable interactable);
}
