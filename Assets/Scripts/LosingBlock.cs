using System.Collections;
using UnityEngine;

public class LosingBlock : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _healthUI;

    private bool _isDead = false;

    private void Update()
    {
        if (_isDead && _playerTransform)
        {
            Vector3 targetCamera = _playerTransform.position - _cameraTransform.position;
            _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation, Quaternion.LookRotation(targetCamera), Time.deltaTime * 10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>() == null)
            return;

        StartCoroutine(nameof(Die));
        _cameraTransform.parent = null;
        _isDead = true;
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        _healthUI.SetActive(false);
        _playerHealth.Die();
    }
}
