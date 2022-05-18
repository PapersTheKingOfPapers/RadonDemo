using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private PlayerInventoryDisplay _playerInventoryDisplay;

    private Dictionary<PickUp.PickUpType, int> _items = new Dictionary<PickUp.PickUpType, int>()
    {
        {PickUp.PickUpType.Wires, 0},
    };

    private void Awake()
    { 
        _playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();

        _playerInventoryDisplay.OnChangeInventory(_items);
    }
    /// <summary>
    /// Add item to Inventory
    /// </summary>
    /// <param name="_pickup">Item type</param>
    public void Add(PickUp _pickup)
    {
        //item's type
        PickUp.PickUpType _type = _pickup.Type;

        //Check Inventory
        if (_items.TryGetValue(_type, out int oldTotal))
        {
            _items[_type] = oldTotal + 1;
        }
        else
        {
            //New Item, so add to inventory
            _items.Add(_type, 1);
        }

        //update GUI
        _playerInventoryDisplay.OnChangeInventory(_items);
    }
}
