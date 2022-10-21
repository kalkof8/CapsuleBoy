using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScrin : MonoBehaviour
{
    [SerializeField] private Image ImageDamage;

    public void StartFlashDamage()
    {
        StartCoroutine(FlashDamage());
    }

    private IEnumerator FlashDamage()
    {
        ImageDamage.enabled = true;
        for (float t = 1f; t > 0f; t-= Time.deltaTime)
        {
            ImageDamage.color = new Color(1, 0, 0, t);
            yield return null;
        }
        ImageDamage.enabled = false;
    }
}
