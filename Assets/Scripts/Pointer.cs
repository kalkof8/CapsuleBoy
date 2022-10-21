using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Joystick _joystickRotation;
    [SerializeField] private float _smoothness;
    [SerializeField] private RopeGun _ropeGun;

    private Vector3 _rotationPointer;
    private Vector3 _rotationPlayer;

    private void Start()
    {
        _rotationPointer = new Vector3(1f, 0f, 0f);
        _rotationPlayer = _playerTransform.rotation.eulerAngles;
    }

    private void LateUpdate()
    {
        if (_joystickRotation.Direction == Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rotationPointer);
            if(_playerMove.IsGrounded == true)
            {
                _playerTransform.rotation = Quaternion.Euler(_rotationPlayer);
            }
        }

        else
        {
            _rotationPointer = new Vector3(_joystickRotation.Direction.x, _joystickRotation.Direction.y, 0f);
            transform.rotation = Quaternion.LookRotation(_rotationPointer);

            if (_playerMove.IsGrounded == true || _ropeGun.CurrentRopeState == RopeState.Activate)
            {
                if (_joystickRotation.Direction.x >= 0)
                    _playerTransform.rotation = Quaternion.Lerp
                        (
                        _playerTransform.rotation,
                        Quaternion.Euler(0f, -45f, 0f),
                        Time.deltaTime * _smoothness
                        );
                if (_joystickRotation.Direction.x < 0)
                    _playerTransform.rotation = Quaternion.Lerp
                        (
                        _playerTransform.rotation,
                        Quaternion.Euler(0f, 45f, 0f),
                        Time.deltaTime * _smoothness
                        );
                if (_ropeGun.CurrentRopeState != RopeState.Activate)
                {
                    _rotationPlayer = _playerTransform.rotation.eulerAngles;
                }
            }
        }
    }
}
