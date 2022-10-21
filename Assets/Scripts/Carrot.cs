using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float _speedCarrot = 8f;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        Rigidbody _rigidbody = GetComponent<Rigidbody>();
        Transform _playerTransform = FindObjectOfType<PlayerMove>().transform;
            Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
            _rigidbody.velocity = toPlayer * _speedCarrot;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
