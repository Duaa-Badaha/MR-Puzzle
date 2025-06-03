using UnityEngine;
using UnityEngine.Events;
using Oculus.Interaction;

public class GrabbableEventRelay : MonoBehaviour
{
    [Header("Grab Events")]
    public UnityEvent OnGrabbed;
    public UnityEvent OnReleased;

    private IPointable _pointable;

    private void Awake()
    {
        // Attempt to get the IPointable component from this GameObject
        _pointable = GetComponent<IPointable>();
        if (_pointable == null)
        {
            Debug.LogError("GrabbableEventHandler requires a component that implements IPointable.");
            enabled = false;
            return;
        }

        // Subscribe to the pointer event
        _pointable.WhenPointerEventRaised += HandlePointerEvent;
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (_pointable != null)
        {
            _pointable.WhenPointerEventRaised -= HandlePointerEvent;
        }
    }

    private void HandlePointerEvent(PointerEvent evt)
    {
        switch (evt.Type)
        {
            case PointerEventType.Select:
                OnGrabbed?.Invoke();
                break;
            case PointerEventType.Unselect:
                OnReleased?.Invoke();
                break;
        }
    }
}
