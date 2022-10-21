using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _eventOnTakeDamage;
    [SerializeField] private UnityEvent _eventOnDieEffect;

    private Score _score;
    private int _health;

    private void Start()
    {
        _score = FindObjectOfType<Score>();
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _eventOnTakeDamage.Invoke();
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _score.RemoveAnimal(this);
        _eventOnDieEffect.Invoke();
        Destroy(gameObject);
    }
}
