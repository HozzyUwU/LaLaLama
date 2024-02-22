using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public byte Health => _currentHealth;

    [Header("Properties")]
    [Space]
    [Range(0, 255)]
    [SerializeField] byte _maxHealth;
    
    byte _currentHealth;

    private void Awake() 
    {
        _currentHealth = _maxHealth;    
    }

    public void Damage(byte damage)
    {
        Debug.Log($"I was damaged by player with {damage}");
        
        _currentHealth = _currentHealth <= damage ? Death() : _currentHealth -= damage;
    }

    private byte Death()
    {
        Debug.Log($"Dead!");
        gameObject.SetActive(false);
        return 0;
    }
}
