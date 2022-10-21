using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _centerRotation;

    private void Update()
    {
        transform.Rotate(_centerRotation * Time.deltaTime);
    }
}
