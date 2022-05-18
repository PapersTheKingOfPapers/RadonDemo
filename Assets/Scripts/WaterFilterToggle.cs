using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fragsurf.Movement;

public class WaterFilterToggle : MonoBehaviour
{
    private CameraWaterCheck _cwc;

    [SerializeField] private SurfCharacter _surfChar;

    [SerializeField] private GameObject _filter;

    private bool _delayOff = false;
    private bool _delayed = false;

    private void Update()
    {
        if(_surfChar.enabled == true)
        {
            if(_delayed == true)
            {
                _cwc = GameObject.Find("Camera water check").GetComponent<CameraWaterCheck>();
                _filter.SetActive(_cwc.IsUnderwater());
            }
            else if(_delayOff == false)
            {
                StartCoroutine(DelayedStart());
                _delayOff = true;
            }
        }
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1);
        _delayed = true;
    }
}
