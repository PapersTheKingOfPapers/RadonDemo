using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fragsurf.Movement;

public class WireRepairRecieveBool : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private string _boolName;
    [SerializeField] private float _requiredTool = 0;

    private float _currentWeapon;
    private bool _activated = false;

    private SurfCharacter _sChar;
    private PlayerAiming _pAim;

    private void Start()
    {
        _sChar = GameObject.FindGameObjectWithTag("Player").GetComponent<SurfCharacter>();
        _pAim = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerAiming>();
    }

    public void Activate()
    {
        Debug.Log(_currentWeapon);
        if(_currentWeapon == _requiredTool)
        {
            _anim.SetBool(_boolName, true);
        }
    }

    private void Update()
    {
        _currentWeapon = WeaponCycle.CurrentScroll;
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("2"))
        {
            _sChar.enabled = false;
            _pAim.enabled = false;
        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("3"))
        {
            _sChar.enabled = true;
            _pAim.enabled = true;

            this.GetComponent<WireRepairRecieveBool>().enabled = false;
        }
    }
}
