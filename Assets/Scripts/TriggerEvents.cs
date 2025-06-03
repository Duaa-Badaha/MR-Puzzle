using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    [SerializeField] string filter;
    [SerializeField] private UnityEvent onTriggerEnterEvents;
    [SerializeField] private UnityEvent onTriggerExitEvents;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(filter)) {
            onTriggerEnterEvents.Invoke();        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(filter))
        {
            onTriggerExitEvents.Invoke();
        }
    }
}
