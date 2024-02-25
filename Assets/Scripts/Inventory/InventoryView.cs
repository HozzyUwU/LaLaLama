using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _holder;
    [SerializeField] private Animator _animator;


    private void Awake() 
    {
        InventoryManager.OnUpdateInventory += UpdateView;    
    }

    private void UpdateView(Stack<string> items)
    {
        ChangeAnimState(items.Count > 0 ? true : false);

        foreach(Transform child in _holder)
        {
            Destroy(child.gameObject);
        }

        Stack<string> words = new Stack<string>(items);
        int count = words.Count;
        for(int i = 0; i < count; i++)
        {
            Instantiate(_itemPrefab, _holder).GetComponentInChildren<TextMeshProUGUI>().text = words.Pop();
        }
    }

    private void ChangeAnimState(bool state)
    {
        _animator.SetBool("IsBurden", state);
    }

    private void OnDestroy() 
    {
        InventoryManager.OnUpdateInventory -= UpdateView;  
    }
}
