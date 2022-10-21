using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private GameObject _checkmark;

    private void Start()
    {
        if (PlayerPrefs.GetString("music") == "no")
        {
            _music.enabled = false;
            _checkmark.SetActive(false);
        }  
    }

    public void SetMusic(bool value)
    {
        if (value)
            PlayerPrefs.SetString("music", "yes");
        else
            PlayerPrefs.SetString("music", "no");
           
        if(PlayerPrefs.GetString("music") == "yes")
        {
            _music.enabled = true;
            _checkmark.SetActive(true);
        }
           
        if(PlayerPrefs.GetString("music") == "no")
        {
            _music.enabled = false;
            _checkmark.SetActive(false);
        }
    }

    public void SetValueMusic(float value)
    {
        _music.volume = value;
    }

    public void SetValueVolume(float value)
    {
        AudioListener.volume = value;
    }
}
