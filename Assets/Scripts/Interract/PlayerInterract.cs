using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterract : MonoBehaviour
{
    [SerializeField] private float _interractRange = 2f;

    private LayerMask _objLayer;

    private void Start()
    {
        _objLayer = LayerMask.GetMask("Obj");
    }

    public void Update()
    {

        RaycastHit _hit;
        if (Input.GetButtonDown("Interract"))
        {
            //Debug.DrawRay(transform.position, transform.forward, Color.yellow, 10f);
            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out _hit, _interractRange, _objLayer))
            {
                //Debug.Log(_hit.transform.gameObject);
                if (_hit.transform.gameObject.GetComponent<ObjectRecieveBool>())
                {
                    //_hit.transform.gameObject.GetComponent<ObjectRecieveBool>().Activate();

                    ObjectRecieveBool[] _temp = _hit.transform.gameObject.GetComponents<ObjectRecieveBool>();

                    foreach(ObjectRecieveBool i in _temp)
                    {
                        i.Activate();
                    }
                }
            }
        }
    }
}
