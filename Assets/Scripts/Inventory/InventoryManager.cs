using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static event Action<Stack<string>> OnUpdateInventory;

    [Header("References")]
    [Space]
    [SerializeField] private Item _itemPrefab;

    private Stack<string> _items = new Stack<string>();

    public void AddItem(string item)
    {
        _items.Push(item);

        OnUpdateInventory?.Invoke(_items);
    }

    public void DropItem()
    {
        if(_items.Count > 0)
        {
            if(Physics2D.OverlapCircle(transform.position + Vector3.right * 2.0f, 0.5f) != null) return;
            string item = _items.Pop();
            _itemPrefab.ItemName = item;
            Instantiate(_itemPrefab, transform.position + Vector3.right * 2.0f, Quaternion.identity);
        }

        OnUpdateInventory?.Invoke(_items);
    }

    public string GetItem()
    {
        if(_items.Count < 1) return "";

        string item = _items.Pop();
        OnUpdateInventory?.Invoke(_items);
        return item;
    }
}
