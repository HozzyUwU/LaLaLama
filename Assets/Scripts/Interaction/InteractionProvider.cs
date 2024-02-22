using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InteractionProvider : MonoBehaviour, IInteractionProvider
{
    [Header("References")]
    [Space]
    [SerializeField] private InventoryManager _inventory;

    [Header("Properties")]
    [Space]
    [Range(1.0f, 2.0f)]
    [SerializeField] private float _interactionRadius;

    public void ProvideInteraction()
    {
        Collider2D obj = Physics2D.OverlapCircle(transform.position, _interactionRadius, 1 << 7);

        if(obj == null)
        {
            _inventory?.DropItem();
            return;
        }

        if(obj.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }
}
