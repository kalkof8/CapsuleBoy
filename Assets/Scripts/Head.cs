using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform _targetHead;

    private void Update()
    {
        transform.position = _targetHead.position;
    }
}
