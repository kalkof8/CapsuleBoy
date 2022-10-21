using UnityEngine;

public class RotateToEulerTarget : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rigthEuler;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _targetEuler;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler), _rotationSpeed * Time.deltaTime);
    }

    public void RotateLeft()
    {
        _targetEuler = _leftEuler;
    }

    public void RotateRigth()
    {
        _targetEuler = _rigthEuler;
    }
}
