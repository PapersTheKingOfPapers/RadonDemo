using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private string _boolName;

    [SerializeField] private MeshRenderer _renderer;

    [SerializeField] private Material _material1;
    [SerializeField] private Material _material2;

    private void Update()
    {
        if(_anim.GetBool(_boolName) == false)
        {
            SetMaterialTo1();
        }
        else if (_anim.GetBool(_boolName) == true)
        {
            SetMaterialTo2();
        }
    }
    private void SetMaterialTo1()
    {
        _renderer.material = _material1;
    }

    private void SetMaterialTo2()
    {
        _renderer.material = _material2;
    }
}
