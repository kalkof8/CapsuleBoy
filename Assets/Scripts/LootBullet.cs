using UnityEngine;

public class LootBullet : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _numbersOfBullets = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(_gunIndex, _numbersOfBullets);
            Destroy(gameObject);
        }
    }
}
