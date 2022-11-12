using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _menuBatton;
    [SerializeField] private GameObject _menuLose;
    [SerializeField] private GameObject _menuQuestion;
    [SerializeField] private GameObject _groupButtonMenu;
    [SerializeField] private GameObject _groupOnLoss;

    [SerializeField] private MonoBehaviour[] _objectsToDeactivate;

    [SerializeField] private Text _fps;
    [SerializeField] private Text _fixed;

    private float _timerUpdate;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        _timerUpdate += Time.deltaTime;
        if (_timerUpdate > 0.15f)
        {
            _timerUpdate = 0f;
            _fps.text = "FPS: " + Mathf.Round(1 / Time.deltaTime).ToString();
            _fixed.text = "FixedUp: " + Mathf.Round(1 / Time.fixedDeltaTime).ToString();
        }
    }

    public void OpenMenuWindow()
    {
        _menuWindow.SetActive(true);
        _menuBatton.SetActive(false);
        _groupOnLoss.SetActive(false);
        for (int i = 0; i < _objectsToDeactivate.Length; i++)
        {
            _objectsToDeactivate[i].enabled = false;
        }
       
        Time.timeScale = 0f;
    }

    public void CloseMenuWindow()
    {
        _menuWindow.SetActive(false);
        _menuBatton.SetActive(true);
        _groupOnLoss.SetActive(true);
        for (int i = 0; i < _objectsToDeactivate.Length; i++)
        {
            _objectsToDeactivate[i].enabled = true;
        }
       
        Time.timeScale = 1f;
    }

    public void OpenWindowQuestion()
    {
        _menuQuestion.SetActive(true);
        _groupButtonMenu.SetActive(false);
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void StayInTheGame()
    {
        _menuQuestion.SetActive(false);
        _groupButtonMenu.SetActive(true);
    }

    public void OpenMenuLose()
    {
        _groupOnLoss.SetActive(false);
        _menuLose.SetActive(true);
        Invoke(nameof(Restart), 3f);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _menuLose.SetActive(false);
    }
}
