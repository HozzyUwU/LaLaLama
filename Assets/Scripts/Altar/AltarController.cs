using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarController : MonoBehaviour, IInteractable
{
    [Header("References")]
    [Space]
    [SerializeField] private InventoryManager _inventory;

    [Header("Holder")]
    [Space]
    [SerializeField] private string _item;

    public void Interact()
    {
        string item = _inventory.GetItem();

        if(item != "")
        {
            _item = item;
        }
    }
}
