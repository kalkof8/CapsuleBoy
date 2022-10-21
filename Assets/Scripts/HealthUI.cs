using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthPrefab;
    [SerializeField] private List<GameObject> _healthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newHealth = Instantiate(_healthPrefab, transform);
            _healthIcons.Add(newHealth);
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            if (i < health)
            {
                _healthIcons[i].SetActive(true);
            }
            else
                _healthIcons[i].SetActive(false);
        }
    }
}
