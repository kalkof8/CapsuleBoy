using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance { get; private set; }

    [SerializeField] private Menu _menu;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private AudioSource _addHealthAudio;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private UnityEvent _eventTakeDamage;

    private bool _invulnerable = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }
    public void TakeDamage(int damage)
    {
        if(_invulnerable == false)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);
            _healthUI.DisplayHealth(_health);
            _eventTakeDamage.Invoke();
        }
    }
    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public bool IsPossibleToAddHealth()
    {
        if (_health < _maxHealth)
            return true;
        else
            return false;
    }

    public void AddHealth(int health)
    {
        _health += health;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealthAudio.Play();
        _healthUI.DisplayHealth(_health);
    }
    public void Die()
    {
        _menu.OpenMenuLose();
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
