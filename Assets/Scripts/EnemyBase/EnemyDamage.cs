using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
            }
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                _enemyHealth.TakeDamage(_damageValue);
            }
        }
        if (_dieOnAnyCollision == true)
        {
            _enemyHealth.TakeDamage(1000);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);

            }
        }
        if (other.GetComponent<Bullet>())
        {
            _enemyHealth.TakeDamage(_damageValue);
        }
        if (_dieOnAnyCollision && other.isTrigger == false)
        {
            _enemyHealth.TakeDamage(1000);
        }
    }
}
