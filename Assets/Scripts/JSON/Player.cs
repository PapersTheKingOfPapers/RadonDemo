using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;

    [SerializeField] private int _health;
    private int _wires;

    public int Health { get => _health; }

    public static Player Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError(message: "No Player");
            }
            return _instance;
        }
    }

    public int Wires { get => _wires; set => _wires = value; }

    [SerializeField] private InventoryManager _inventoryManager;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        
    }

    private void LoadPlayerDataFromJSON()
    {

    }
}
