using UnityEngine;

public class LootHealth : MonoBehaviour
{
    [SerializeField] private int _numbersOfHealth = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth.IsPossibleToAddHealth())
            {
                playerHealth.AddHealth(_numbersOfHealth);
                Destroy(gameObject);
            }
        }
    }
}
