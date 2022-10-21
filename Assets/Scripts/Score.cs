using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private List<EnemyHealth> _allAnimals = new List<EnemyHealth>();
    [SerializeField] private Text _allAnimalsText;
    [SerializeField] private Text _bestScoreText;


    private void Start()
    {
        if (PlayerPrefs.GetInt("score") == 0 && PlayerPrefs.GetString("win") != "yes")
        {
            PlayerPrefs.SetInt("score", _allAnimals.Count);
        }
        _bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("score");
        _allAnimalsText.text = "Осталось животных: " + _allAnimals.Count.ToString();
    }

    public void RemoveAnimal(EnemyHealth enemyHealth)
    {
        _allAnimals.Remove(enemyHealth);
        _allAnimalsText.text = "Осталось животных: " + _allAnimals.Count.ToString();
        if(PlayerPrefs.GetInt("score") > _allAnimals.Count)
        {
            PlayerPrefs.SetInt("score", _allAnimals.Count);
            _bestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("score");
        }
        if (_allAnimals.Count == 0)
        {
            PlayerPrefs.SetString("win", "yes");
        }
    }
}
