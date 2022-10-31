using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool IsGrounded;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpTorque;
    [SerializeField] private Rigidbody _rigidbody;

    private int _jumpFramUpdate;
    private float _timerJump = 0f;
    private float _periodJump = 0.1f;

    private void Update()
    {
        _timerJump += Time.deltaTime;

        if (_joystick.Vertical > 0.7f && IsGrounded && _timerJump > _periodJump)
        {
            _timerJump = 0f;
            Jump();
        }
        if (IsGrounded == false || _joystick.Vertical < -0.6f)
        {
            _playerTransform.localScale = Vector3.Lerp(_playerTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 10f);
        }
        else
            _playerTransform.localScale = Vector3.Lerp(_playerTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    }

    public void Jump()
    {
        _jumpFramUpdate = 0;
        _rigidbody.AddForce(0f, _jumpSpeed, 0f, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        _jumpFramUpdate++;
        float speedMultiplier = 1f;
        if (IsGrounded == false)
        {
            speedMultiplier = 0.5f;
            if (_rigidbody.velocity.x > _maxSpeed && _joystick.Horizontal > 0)
            {
                speedMultiplier = 0f;
            }
            if (_rigidbody.velocity.x < -_maxSpeed && _joystick.Horizontal < 0)
            {
                speedMultiplier = 0f;
            }
        }

        if(_joystick.Horizontal > 0.3f || _joystick.Horizontal < -0.3f)
        {
            _rigidbody.AddForce(_joystick.Horizontal * _moveSpeed * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
        }

        if (IsGrounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
        }

        if (_jumpFramUpdate == 3) 
        {
            if(IsGrounded == false)
            {
                _rigidbody.freezeRotation = false;
                _rigidbody.AddTorque(0f, 0f, _jumpTorque, ForceMode.VelocityChange);
            }
        }
    }
   
    private void OnCollisionStay(Collision collision)
    {
        float angel = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angel < 45)
        {
            IsGrounded = true;
            _rigidbody.freezeRotation = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
