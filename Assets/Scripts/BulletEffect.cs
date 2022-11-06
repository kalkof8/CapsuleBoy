using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    public void StartDeactivate()
    {
        Invoke(nameof(Deactivate), 1f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
