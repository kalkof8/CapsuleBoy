using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [SerializeField] private float _timeScale = 0.2f;

    private float _startFixedDeltaTime;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    public void OnButtonDown()
    {
        Time.timeScale = _timeScale;
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }
   
    public void OnButtonUp()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
