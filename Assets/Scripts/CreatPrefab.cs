using UnityEngine;

public class CreatPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawn;

    public void Creator()
    {
        Instantiate(_prefab, _spawn.position, _spawn.rotation);
    }
}
