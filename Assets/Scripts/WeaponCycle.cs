using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WeaponCycle : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private int _scrollAmount;
    [SerializeField] private float _maxScroll;
    [SerializeField] private string _weaponTrigger;

    public bool _allowAttack = true;

    public bool _allowScroll = true;

    [SerializeField] private Animator _hudAnim;
    [SerializeField] private string _hudBoolName;
    [SerializeField] private Image[] _hudImages;
    [SerializeField] private Color _hudNotSelected;
    [SerializeField] private Color _hudSelected;
    private bool _toolHudState = false;

    private static float _currentScroll = 0;

    private int _previousWeaponState;

    private Coroutine _co;

    public static float CurrentScroll { get => _currentScroll;}

    public void Start()
    {
        if(_hudImages.Length != _maxScroll+1)
        {
            Debug.LogWarning("Warning, Hud Images Array is different size than Max Scroll amount.");
        }

        _co = StartCoroutine(ToggleHud());
        StopCoroutine(_co);
        _toolHudState = false;
    }

    private void Update()
    {
        if(_allowScroll == true)
        {
            ScrollUpdate();
        }
        UpdateAnimation();
        HudUpdate();
    }

    void ScrollUpdate()
    {
        
        float _temp = Input.mouseScrollDelta.y;

        _currentScroll = Mathf.Clamp(_currentScroll, 0, _maxScroll);

        if (_temp > 0)
        {
            _currentScroll -= _scrollAmount;
            _temp = 0;
            StopCoroutine(_co);
            _co = StartCoroutine(ToggleHud());
        }
        else if (_temp < 0)
        {
            _currentScroll += _scrollAmount;
            _temp = 0;
            StopCoroutine(_co);
            _co = StartCoroutine(ToggleHud());
        }
    }

    void UpdateAnimation()
    {
        _previousWeaponState = _anim.GetInteger("CurrentWeaponRight");
        if(Input.GetButtonDown("Fire1") && _toolHudState == true)
        {
            _anim.SetInteger("CurrentWeaponRight", Mathf.RoundToInt(_currentScroll));
            _anim.SetTrigger(_weaponTrigger);
            StopCoroutine(_co);
            _toolHudState = false;
        }
    }

    void HudUpdate()
    {
        _allowAttack = !_toolHudState;
        _hudAnim.SetBool(_hudBoolName, _toolHudState);

        for(int i = 0; i < _hudImages.Length; i++)
        {
            if(i == _currentScroll)
            {
                _hudImages[i].color = _hudSelected;
            }
            else
            {
                _hudImages[i].color = _hudNotSelected;
            }
        }
    }

    void ResetTrigger()
    {
        _anim.ResetTrigger(_weaponTrigger);
    }

    IEnumerator ToggleHud() 
    {
        _toolHudState = true;
        yield return new WaitForSeconds(5);
        _toolHudState = false;
    }
}
