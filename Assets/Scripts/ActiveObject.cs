using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _animals;

    private Transform _player;
    private float _distance;

    private void Start()
    {
        _player = PlayerHealth.instance.transform;
    }

    private void Update()
    {
        for (int i = 0; i < _animals.Length; i++)
        {
            if(_animals[i]!= null)
            {
                _distance = Vector3.Distance(_player.position, _animals[i].gameObject.transform.position);
                if (_distance < 20f)
                    _animals[i].SetActive(true);
                else
                    _animals[i].SetActive(false);
            }
        }
    }
}
