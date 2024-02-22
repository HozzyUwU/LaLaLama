using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour, IMovable
{
    public float MovementSpeed => _movementSpeed;

    [SerializeField] private float _movementSpeed;
    
    private Rigidbody _rigidbody;

    private void Awake() 
    {
        if(!TryGetComponent<Rigidbody>(out _rigidbody))
        {
            Debug.LogWarning("There Is No Rigidbody");
        }    
    }

    public void Move(Vector2 direction)
    {
        Vector2 _velocityChange = direction * _movementSpeed - (Vector2)_rigidbody.velocity;
        _rigidbody.AddForce(_velocityChange, ForceMode.VelocityChange);
    }
}
