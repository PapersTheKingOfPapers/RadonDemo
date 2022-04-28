using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCycle : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    [SerializeField] private int _scrollAmount;

    [SerializeField] private float _maxScroll;

    [SerializeField] private string _weaponTrigger;

    private static float _currentScroll = 0;

    private int _previousWeaponState;

    public static float CurrentScroll { get => _currentScroll;}

    private void Update()
    {
        float _temp = Input.mouseScrollDelta.y;

        _currentScroll = Mathf.Clamp(_currentScroll, 0, _maxScroll);

        if (_temp > 0)
        {
            _currentScroll += _scrollAmount;
                    _temp = 0;
        }
        else if(_temp < 0)
        {
            _currentScroll -= _scrollAmount;
            _temp = 0;
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        _previousWeaponState = _anim.GetInteger("CurrentWeaponRight");
        _anim.SetInteger("CurrentWeaponRight", Mathf.RoundToInt(_currentScroll));

        if (_previousWeaponState != _currentScroll)
        {
            _anim.SetTrigger(_weaponTrigger);
        }


    }

    void ResetTrigger()
    {
        _anim.ResetTrigger(_weaponTrigger);
    }
}
