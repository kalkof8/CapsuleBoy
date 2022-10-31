using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxSpeedRotate;
    [SerializeField] private Rigidbody _rigidbody;
    
    private void Start()
    {
        _rigidbody.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        _rigidbody.AddRelativeTorque(
            Random.Range(-_maxSpeedRotate, _maxSpeedRotate),
            Random.Range(-_maxSpeedRotate, _maxSpeedRotate),
            Random.Range(-_maxSpeedRotate, _maxSpeedRotate)
            );
    }
}
