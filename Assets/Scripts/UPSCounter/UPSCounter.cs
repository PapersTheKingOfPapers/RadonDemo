using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fragsurf.Movement;
using TMPro;

public class UPSCounter : MonoBehaviour
{
    public TMP_Text _upsCounter;

    private SurfCharacter _upsTracked;

    private float _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _upsTracked = GameObject.FindGameObjectWithTag("Player").GetComponent<SurfCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = _upsTracked.moveData.velocity.magnitude;
        _upsCounter.text = "UPS: " + _velocity;
    }
}
