using UnityEngine;

public class Chiken : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;

    private Transform _playerTransform;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        _rigidbody = GetComponent<Rigidbody>();
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
