using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxCharge;
    [SerializeField] private Gun[] _gun;
    [SerializeField] private IconCharge _iconCharge;
    [SerializeField] private PlayerArmory _playerArmory;
    [SerializeField] private PlayerMove _playerMove;

    private float _currentCharge;
    private bool _isCharge;

    private void Update()
    {
        _currentCharge += Time.unscaledDeltaTime;
        _iconCharge.SetChargeValue(_currentCharge, _maxCharge);
        if (_currentCharge >= _maxCharge)
        {
            _isCharge = true;
            _iconCharge.StopCharge();
        }
    }

    public void Jump()
    {
        if (_isCharge == false)
            return;

        _playerRigidbody.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
        _gun[_playerArmory.CurrentGunIndex].Shot();
        _isCharge = false;
        _currentCharge = 0f;
        _iconCharge.StartCharge();
    }
}
