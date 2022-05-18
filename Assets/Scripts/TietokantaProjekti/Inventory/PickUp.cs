using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Type of item moved to inventory
/// </summary>
public class PickUp : MonoBehaviour
{
    public enum PickUpType
    {
        Wires
    }
    // Shows up in editor
    [SerializeField] private PickUpType _type;

    //Only get;
    public PickUpType Type { get => _type;}
}
