using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 3f;
    [SerializeField] private Vector3 _leftTurn;
    [SerializeField] private Vector3 _rightTurn;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
        if (_playerTransform == null)
            return;

        if(transform.position.x > _playerTransform.position.x)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_leftTurn), Time.deltaTime * _speedRotation);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rightTurn), Time.deltaTime * _speedRotation);
        }
    }
}
