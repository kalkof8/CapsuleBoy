using UnityEngine;

public class BatchCreatPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawn;

    [ContextMenu("Create")]
    public void Create()
    {
        for (int i = 0; i < _spawn.Length; i++)
        {
            Instantiate(_prefab, _spawn[i].position, _spawn[i].rotation);
        }
    }
}
