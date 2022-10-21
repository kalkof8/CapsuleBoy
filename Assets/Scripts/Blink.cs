using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderePlayers;


    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        for(float t = 0; t <= 1; t += Time.deltaTime)
        {
            for (int i = 0; i < _renderePlayers.Length; i++)
            {
                for (int j = 0; j < _renderePlayers[i].materials.Length; j++)
                {
                    _renderePlayers[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t*30) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }
        for (int i = 0; i < _renderePlayers.Length; i++)
        {
            for (int j = 0; j < _renderePlayers[i].materials.Length; j++)
            {
                _renderePlayers[i].materials[j].SetColor("_EmissionColor", new Color(0, 0, 0, 0));
            }
        }
        StopCoroutine(BlinkEffect());
    }
}
