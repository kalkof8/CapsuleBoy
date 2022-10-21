using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletEffect;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_bulletEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LootHealth>() == null && other.GetComponent<LootBullet>() == null)
        {
            Instantiate(_bulletEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
