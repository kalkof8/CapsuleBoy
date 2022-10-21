using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody Rigidbody;

    [SerializeField] private Collider _hookCollider;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Rigidbody _playerRigigdbody;
    [SerializeField] private RopeGun _ropeGan;

    private FixedJoint _fixedJoint;

    private void Start()
    {
        Physics.IgnoreCollision(_hookCollider, _playerCollider);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            _ropeGan.CreatSpring();
        }
    }

    public void StopFix()
    {
        if(_fixedJoint)
            Destroy(_fixedJoint);
    }
}
