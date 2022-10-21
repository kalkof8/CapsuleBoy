using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed;

    private void Update()
    {
        if(_target)
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _followSpeed);
    }
}
