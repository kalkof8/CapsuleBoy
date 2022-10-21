using UnityEngine;

public class SetTrigger : MonoBehaviour
{
    [SerializeField] private float _period = 7f;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _trigger = "Attack";

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _period)
        {
            _timer = 0f;
            _animator.SetTrigger(_trigger);
        }
    }
}
