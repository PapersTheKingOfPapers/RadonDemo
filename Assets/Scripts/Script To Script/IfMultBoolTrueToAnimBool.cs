using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfMultBoolTrueToAnimBool : MonoBehaviour
{
    [Header("Animators where the bools are coming from (Inputs)")]
    [SerializeField] private Animator[] _animFrom;
    [SerializeField] private string[] _fromParaName;

    [Header("Animators where the bools are going to (Outputs)")]
    [SerializeField] private Animator[] _animTo;
    [SerializeField] private string[] _toParaName;

    [Header("Variables")]
    [Tooltip("When toggled, does it stay that way?")]
    [SerializeField] private bool _persist = false;

    private bool _toggled = false;

    private void Update()
    {
        if (IsAllBoolTrue() && _toggled == false)
        {
            for (int i = 0; i < _animTo.Length; i++)
            {
                _animTo[i].SetBool(_toParaName[i], true);
            }

            if (_persist == true)
            {
                _toggled = true;
            }
        }
        else
        {
            if(_toggled == false)
            {
                for (int i = 0; i < _animTo.Length; i++)
                {
                }
            }
        }
    }
    private bool IsAllBoolTrue()
    {
        for (int i = 0; i < _animFrom.Length; i++)
        {
            if (_animFrom[i].GetBool(_fromParaName[i]) == false)
            {
                return false;
            }
        }

        return true;
    }
}
