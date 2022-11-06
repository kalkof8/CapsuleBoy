using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string _tagEffect;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject objEffect =  ObjectPooler.Instance.SpawFromPool(_tagEffect, transform.position, Quaternion.identity);
        objEffect.GetComponent<BulletEffect>().StartDeactivate();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LootHealth>() == null && other.GetComponent<LootBullet>() == null)
        {
            ObjectPooler.Instance.SpawFromPool(_tagEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    public void StartDeactivate()
    {
        Invoke(nameof(Deactivate), 2f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
