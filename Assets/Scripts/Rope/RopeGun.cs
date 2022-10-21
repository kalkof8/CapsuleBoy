using UnityEngine;

public enum RopeState { 
    Desabled, 
    Fly,
    Activate
}

public class RopeGun : MonoBehaviour
{
    public RopeState CurrentRopeState;

    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _ropeStart;
    [SerializeField] private RopeRenderer _ropeRenderer;
    [SerializeField] private PlayerMove _playerMove;

    private SpringJoint _springJoint;
    private float _leanthRope;

    private void Update()
    {
        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            if(distance > 20f)
            {
                _hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Desabled;
                _ropeRenderer.Hide();
            }
        }
        if (CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Activate)
        {
            _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _leanthRope);
        }
    }

    public void Shot()
    {
        if(CurrentRopeState == RopeState.Activate && _playerMove.IsGrounded == true)
        {
            DestroyRope();
            return;
        }
        if(CurrentRopeState == RopeState.Activate && _playerMove.IsGrounded == false)
        {
            _playerMove.Jump();
            DestroyRope();
            return;
        }

        _leanthRope = 1f;

        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        _hook.gameObject.SetActive(true);
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;

        CurrentRopeState = RopeState.Fly;
    }

    public void CreatSpring()
    {
        if(_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.anchor = _ropeStart.localPosition;
            _springJoint.connectedBody = _hook.Rigidbody;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = new Vector3(0f, 0f, 0f);
            _leanthRope = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            _springJoint.maxDistance = _leanthRope;
            _springJoint.spring = 100f;
            _springJoint.damper = 10f;
        }
        CurrentRopeState = RopeState.Activate;
        Time.fixedDeltaTime = 0.004f;
    }

    public void DestroyRope()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
            CurrentRopeState = RopeState.Desabled;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
        Time.fixedDeltaTime = 0.02f;
    }
}
