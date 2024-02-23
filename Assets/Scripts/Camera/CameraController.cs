using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private Transform _playerTransform;

    [Header("Properties")]
    [Space]
    [SerializeField] private float _smoothTime = 0.3f;
    [SerializeField] private float _height = 20;
    private Vector3 _currentVelocity = Vector3.zero;
    
    private void FixedUpdate() 
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z),
            ref _currentVelocity,
            _smoothTime,
            Mathf.Infinity,
            Time.fixedDeltaTime
        );

        Camera.main.orthographicSize = _height;
    }
}
