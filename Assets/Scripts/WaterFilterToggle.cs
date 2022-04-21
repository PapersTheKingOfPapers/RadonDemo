using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFilterToggle : MonoBehaviour
{
    private CameraWaterCheck _cwc;

    [SerializeField] private GameObject _filter;

    private void Update()
    {
        _cwc = GameObject.Find("Camera water check").GetComponent<CameraWaterCheck>();
        _filter.SetActive(_cwc.IsUnderwater());
    }
}
