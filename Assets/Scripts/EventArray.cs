using UnityEngine;
using UnityEngine.Events;

public class EventArray : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _event;
    
    public void StartEvent(int indexEvents)
    {
        _event[indexEvents].Invoke();
    }
}
