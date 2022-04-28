using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
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
        if (Input.GetButtonDown("Interact"))
        {
            //Debug.DrawRay(transform.position, transform.forward, Color.yellow, 10f);
            
            if (Physics.SphereCast(transform.position, 0.25f, transform.forward, out _hit, _interractRange, _objLayer))
            {
                //Debug test to show hit position and range it affects.

                //GameObject _debugSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //_debugSphere.transform.position = _hit.point;
                //_debugSphere.transform.SetParent(null);
                //_debugSphere.transform.localScale *= 0.5f;
                //_debugSphere.gameObject.name = "_debugSphere";

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

                else if (_hit.transform.gameObject.GetComponent<WireRepairRecieveBool>())
                {
                    //_hit.transform.gameObject.GetComponent<WireRepairRecieveBool>().Activate();

                    WireRepairRecieveBool[] _temp = _hit.transform.gameObject.GetComponents<WireRepairRecieveBool>();

                    foreach (WireRepairRecieveBool i in _temp)
                    {
                        i.Activate();
                    }
                }
            }
        }
    }
}
