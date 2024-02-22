using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public event Action OnUpdateInventory;

    [Header("References")]
    [Space]
    [SerializeField] private Item _itemPrefab;

    private Stack<string> _items = new Stack<string>();

    public void AddItem(string item)
    {
        _items.Push(item);

        OnUpdateInventory?.Invoke();
    }

    public void DropItem()
    {
        if(_items.Count > 0)
        {
            string item = _items.Pop();
            _itemPrefab.ItemName = item;
            Instantiate(_itemPrefab, transform.position + Vector3.right * 2.0f, Quaternion.identity);
        }

        OnUpdateInventory?.Invoke();
    }

    public string GetItem()
    {
        if(_items.Count < 1) return "";

        return _items.Pop();
    }
}
