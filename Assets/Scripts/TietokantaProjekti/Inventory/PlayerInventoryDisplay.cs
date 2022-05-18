using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayerInventoryDisplay : MonoBehaviour
{
    // GUI
    [SerializeField] private TMP_Text _inventoryText;

    /// <summary>
    /// Updates inventory GUI
    /// </summary>
    /// <param name="_inventory">Player Inventory</param>
    public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> _inventory)
    {
        _inventoryText.text = "";
        string _newInventoryText = "Inventory: ";

        //Go through each item in inventory
        foreach(var _item in _inventory)
        {
            int _itemTotal = _item.Value;
            string _description = _item.Key.ToString();
            _newInventoryText += $"{_description}: {_itemTotal} ";
        }

        //int _numItems = _inventory.Count;
        if (_inventory.Count < 1)
        {
            _newInventoryText = "(You poor bitch.)";
        }

        _inventoryText.text = _newInventoryText;
    }
}
