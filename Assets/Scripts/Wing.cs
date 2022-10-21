using UnityEngine;

public class Wing : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
