using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour, IItem
{
    public string ItemName
    {
        get { return _word; }
        set { _word = value; }
    }

    [Header("Properties")]
    [Space]
    [SerializeField] private string _word;

    [Header("References")]
    [Space]
    [SerializeField] private TextMeshProUGUI _text;
    private Rigidbody2D _rigidbody;

    private void Awake() 
    {
        _text.text = _word;    

        if(!TryGetComponent<Rigidbody2D>(out _rigidbody))
        {
            Debug.LogWarning("There Is No Rigidbody");
        }
    }

    public void DropItem()
    {
        _rigidbody.AddForce(Vector2.one, ForceMode2D.Impulse);
    }

    public void DestroyItem()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(_text.text != "" && other.tag == "Player")
        {
            if(other.TryGetComponent<InventoryManager>(out InventoryManager inventoryManager))
            {
                inventoryManager.AddItem(_word);
                DestroyItem();
            }
        }
    }
}
