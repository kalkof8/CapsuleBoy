using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public int CurrentGunIndex;

    [SerializeField] private Gun[] _guns;

    private void Start()
    {
        TakeGunByIndex(CurrentGunIndex);
    }

    public void TakeGunByIndex(int indexGun)
    {
        CurrentGunIndex = indexGun;
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == indexGun)
                _guns[i].Activate();
            else
                _guns[i].Deactivate();
        }
    }

    public void AddBullets(int indexByGun, int numberOfBullets)
    {
        _guns[indexByGun].AddBullets(numberOfBullets);
    }
}
