using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AltarView : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private TextMeshProUGUI _textUI;
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private Transform[] _dropPoints;

    private void Awake() 
    {
        AltarController.OnAltarUpdate += UpdateView;    
        AltarController.OnAltarLose += DropItems;
        AltarController.OnAltarWin += WinLogic;
    }

    private void WinLogic(List<string> list)
    {
        Debug.Log($"Победа: Ты {list[0]}, {list[1]}, {list[2]}");
    }

    private void DropItems(List<string> items)
    {
        for(int i = 0; i < items.Count; i++)
        {
            _itemPrefab.ItemName = items[i];
            Instantiate(_itemPrefab, _dropPoints[i].position, Quaternion.identity);
        }
    }

    private void UpdateView(List<string> items)
    {
        _textUI.text = _textUI.text = $"Ты {(items.Count >= 1 ? items[0] : "...")},  {(items.Count >= 2 ? items[1] : "...")},  {(items.Count >= 3 ? items[2] : "...")}";
    }

    private void OnDestroy() 
    {
        AltarController.OnAltarUpdate -= UpdateView;    
        AltarController.OnAltarLose -= DropItems;
        AltarController.OnAltarWin -= WinLogic;    
    }
}
