using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(IFuzzyProvider))]
public class AltarController : MonoBehaviour, IInteractable
{
    public static event Action<List<string>> OnAltarUpdate;
    public static event Action<List<string>> OnAltarLose;
    public static event Action<List<string>> OnAltarWin;

    public List<string> Items => _items;

    [Header("References")]
    [Space]
    [SerializeField] private InventoryManager _inventory;
    private IFuzzyProvider _fuzzyProvider;

    [Header("Holder")]
    [Space]
    [SerializeField] private List<string> _items = new List<string>();

    private void Awake() 
    {
        if(!TryGetComponent<IFuzzyProvider>(out _fuzzyProvider))
        {
            Debug.LogWarning("There Is No IFuzzyProvider");
        }    
    }

    public void Interact()
    {
        string item = _inventory.GetItem();

        if(item != "")
        {
            _items.Add(item);
            Debug.Log($"Fuzzy score: {_fuzzyProvider.ProvideFuzzyCalculation(_items)}");

            if(_items.Count == 3)
            {
                FuzzyLogic();
            }

            OnAltarUpdate?.Invoke(_items);
        }
    }

    private void FuzzyLogic()
    {
        if(_fuzzyProvider.ProvideFuzzyCalculation(_items) < 100.0f)
        {
            OnAltarLose?.Invoke(_items);
        }else
        {
            OnAltarWin?.Invoke(_items);
        }

        _items.Clear();
    }
}
