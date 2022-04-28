using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBoolToAnimBool : MonoBehaviour
{
    [Header("Animator where the bool is coming from (Input)")]
    [SerializeField] private Animator _animFrom;
    [SerializeField] private string _fromParaName;

    [Header("Animator where the bool is going to (Output)")]
    [SerializeField] private Animator[] _animTo;
    [SerializeField] private string[] _toParaName;

    [Header("Variables")]
    [Tooltip("When toggled, does it stay that way?")]
    [SerializeField] private bool _persist = false;

    private bool _toggled = false;

    private void Update()
    {
        if (_toggled == false && _animFrom.GetBool(_fromParaName) != _animTo[0].GetBool(_toParaName[0]))
        {
            for(int i = 0; i < _animTo.Length; i++)
            {
                _animTo[i].SetBool(_toParaName[i], _animFrom.GetBool(_fromParaName));
            }

            if(_persist == true)
            {
                _toggled = true;
            }
        }
    }
}
