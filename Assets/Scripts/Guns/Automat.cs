using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    [SerializeField] private int _numbersOfBullets;
    [SerializeField] private Text _textBullets;
    [SerializeField] private PlayerArmory _playerArmory;
    [SerializeField] private AudioSource _addBulletAudio;

    public override void Shot()
    {
        base.Shot();
        _numbersOfBullets--;
        UpdateText();
        if (_numbersOfBullets == 0)
        {
            OnButtonUp();
            _playerArmory.TakeGunByIndex(0);
        }
    }

    private void UpdateText()
    {
        _textBullets.text = "Пули: " + _numbersOfBullets.ToString();
    }

    public override void Activate()
    {
        base.Activate();
        _textBullets.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _textBullets.enabled = false;
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        _addBulletAudio.Play();
        _numbersOfBullets += numberOfBullets;
        UpdateText();
        _playerArmory.TakeGunByIndex(1);
    }
}
