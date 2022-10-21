using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _flash;
    [SerializeField] private ParticleSystem _smokePartical;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speedBullet = 20f;
    [SerializeField] private float _timeReloading = 0.02f;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] private GameObject[] _buttons;

    private bool _isPressed;
    private float _timer;

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;
       
        if (_isPressed)
        {
            if(_timer > _timeReloading)
            {
                _timer = 0f;
                Shot();
            }
        }
    }
    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _speedBullet;
        _audioSource.Play();
        _flash.SetActive(true);
        _smokePartical.Play();
        Invoke(nameof(DisableFlash), 0.1f);
    }
    private void DisableFlash()
    {
        _flash.SetActive(false);
    }
    public void OnButtonDown()
    {
        _isPressed = true;
    }

    public void OnButtonUp()
    {
        _isPressed = false;
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].SetActive(true);
        }
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].SetActive(false);
        }
    }

    public virtual void AddBullets(int numberOfBullets)
    {

    }
}
