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

    private AnimatorStateInfo _stateInfo;
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
    public string GetCurrentClipName()
    {
        _stateInfo = _anim.GetCurrentAnimatorStateInfo(0);

        return _stateInfo.fullPathHash.ToString();
    }

    private void Update()
    {
        Debug.Log(GetCurrentClipName());
        _currentWeapon = WeaponCycle.CurrentScroll;
        if (GetCurrentClipName() == "2")
        {
            _sChar.enabled = false;
            _pAim.enabled = false;
        }
        else if (GetCurrentClipName() == "3")
        {
            _sChar.enabled = true;
            _pAim.enabled = true;

            this.GetComponent<WireRepairRecieveBool>().enabled = false;
        }
    }
}
