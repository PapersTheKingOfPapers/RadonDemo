using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToORB : MonoBehaviour
{
    [SerializeField] private ObjectRecieveBool[] _oRB;

    [SerializeField] private bool _persist = false;
    private bool _triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _triggered == false)
        {
            if(_persist == true)
            {
                _triggered = true;
            }
            foreach (ObjectRecieveBool i in _oRB)
            {
                i.Activate();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _triggered == false)
        {
            foreach (ObjectRecieveBool i in _oRB)
            {
                i.Activate();
            }
        }
    }
}
