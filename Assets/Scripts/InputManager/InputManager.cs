using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{ 
    [Header("References")]
    [Space]
    [SerializeField] private MenuController _menu;

    private IMovable _playerMovement;
    private IAttackProvider _playerCombat;
    private IInteractionProvider _interactionProvider;

    private PlayerInput _playerInput;


    private void Awake() 
    {
        _playerInput = new PlayerInput();

        _playerInput.Movement.Enable();
        _playerInput.Combat.Enable();
        _playerInput.Interaction.Enable();

        if(!TryGetComponent<IMovable>(out _playerMovement))
        {
            Debug.LogWarning("There Is No IMovable object");
        }

        if(!TryGetComponent<IAttackProvider>(out _playerCombat))
        {
            Debug.LogWarning("There Is No IAttackProvider object");
        }

        if(!TryGetComponent<IInteractionProvider>(out _interactionProvider))
        {
            Debug.LogWarning("There Is No IInteractionProvider object");
        }

        _playerInput.Combat.Attack.started += ProvideAttack;
        _playerInput.Interaction.Interact.started += ProvideInteraction;
    }


    private void FixedUpdate()
    {
        if(_menu.IsPause) return;

        Movement();
    }
    
    private void ProvideInteraction(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(_menu.IsPause) return;
        
       _interactionProvider.ProvideInteraction();
    }

    private void ProvideAttack(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(_menu.IsPause) return;

        _playerCombat.Attack();
    }

    private void Movement()
    {
        _playerMovement.Move(_playerInput.Movement.MovementDirection.ReadValue<Vector2>());
    }

    private void OnDestroy() 
    {
        _playerInput.Combat.Attack.started -= ProvideAttack;
        _playerInput.Interaction.Interact.started -= ProvideInteraction;
    }
}
