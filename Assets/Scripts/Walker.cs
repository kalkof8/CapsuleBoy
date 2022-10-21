using UnityEngine;
using UnityEngine.Events;

public class Walker : MonoBehaviour
{
    [SerializeField] private Direction _currentDirection;
    [SerializeField] private UnityEvent _eventRotateToLeft;
    [SerializeField] private UnityEvent _eventRotateToRigth;
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rigthTarget;
    [SerializeField] private Transform _raycastStart;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _timeStop = 1f;
   
    private enum Direction { left, rigth };
    private bool _isStopped;
    

    private void Start()
    {
        _leftTarget.parent = null;
        _rigthTarget.parent = null;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_raycastStart.position, Vector3.down, out hit))
            transform.position = hit.point;

        if (_isStopped)
            return;

        if (_currentDirection == Direction.left)
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0f, 0f);
            if(transform.position.x < _leftTarget.position.x)
            {
                _currentDirection = Direction.rigth;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _timeStop);
                _eventRotateToLeft.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0f, 0f);
            if(transform.position.x > _rigthTarget.position.x)
            {
                _currentDirection = Direction.left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _timeStop);
                _eventRotateToRigth.Invoke();
            }
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}
