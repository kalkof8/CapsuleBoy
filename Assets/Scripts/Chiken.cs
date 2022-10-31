using UnityEngine;

public class Chiken : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;
    [SerializeField] private Rigidbody _rigidbody;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = PlayerHealth.instance.transform;
    }
    
    private void FixedUpdate()
    {
        if (_playerTransform == null)
            return;

        Vector3 toTarget = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toTarget * _speed - _rigidbody.velocity) / _timeToReachSpeed;
        _rigidbody.AddForce(force);
    }
}
