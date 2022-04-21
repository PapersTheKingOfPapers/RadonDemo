using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRecieveBool : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private string _boolName;
    private bool _currentBool;
    private bool _activated = false;

    [SerializeField] private bool _timed = false;
    [SerializeField] private int _waitSeconds = 2;

    [SerializeField] private bool _delayed = false;
    [SerializeField] private int _delaySeconds = 1;

    [Tooltip("When toggled, does it stay that way?")]
    [SerializeField] private bool _persist = false;

    public void Activate()
    {
        if(_activated == true)
        {
            return;
        }

        if(_delayed == true)
        {
            StartCoroutine(Delay());
            _activated = true;
        }
        else if (_timed == true)
        {
            StartCoroutine(Timer());
            _anim.SetBool(_boolName, !_anim.GetBool(_boolName));
            _activated = true;
        }
        else
        {
            _anim.SetBool(_boolName, !_anim.GetBool(_boolName));
            if(_persist == true)
            {
                _activated = true;
            }
        }

        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delaySeconds);
        _anim.SetBool(_boolName, !_anim.GetBool(_boolName));
        if(_persist == false)
        {
            _activated = false;
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_waitSeconds);
        _anim.SetBool(_boolName, !_anim.GetBool(_boolName));
        if (_persist == false)
        {
            _activated = false;
        }
    }
}
