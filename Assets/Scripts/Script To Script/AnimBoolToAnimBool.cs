using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBoolToAnimBool : MonoBehaviour
{
    [Header("Animator where the bool is coming from (Input)")]
    [SerializeField] private Animator _animFrom;
    [SerializeField] private string _fromParaName;

    [Header("Animator where the bool is going to (Output)")]
    [SerializeField] private Animator _animTo;
    [SerializeField] private string _toParaName;

    [Header("Variables")]
    [Tooltip("When toggled, does it stay that way?")]
    [SerializeField] private bool _persist = false;

    private bool _toggled = false;

    private void Update()
    {
        if(_animFrom.GetBool(_fromParaName) == true && _toggled == false)
        {
            _animTo.SetBool(_toParaName, !_animTo.GetBool(_toParaName));

            if(_persist == true)
            {
                _toggled = true;
            }
        }
    }
}
