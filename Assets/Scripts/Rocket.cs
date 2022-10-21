using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 1f;
    [SerializeField] private float _speedMove = 10f;

    private Transform _playerTransform;
   
    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
        if (_playerTransform)
        {
            transform.position += Time.deltaTime * transform.forward * _speedMove;
            Vector3 toTarget = _playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(toTarget, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _speedRotation);
        }
    }
}
