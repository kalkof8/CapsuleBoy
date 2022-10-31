using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float _speedCarrot = 8f;
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform _playerTransform = PlayerHealth.instance.transform;
            Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
            _rigidbody.velocity = toPlayer * _speedCarrot;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
