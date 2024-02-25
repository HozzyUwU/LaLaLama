using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProvider : MonoBehaviour, IAttackProvider
{
    [Header("References")]
    [Space]
    [SerializeField] private Animator _animator;

    [Header("Properties")]
    [Space]
    [Range(1.0f, 2.0f)]
    [SerializeField] private float _attackRadius;
    [Range(0.2f, 1.0f)]
    [SerializeField] private float _attackCooldown;
    [SerializeField] private byte _damage;
    private float _currentAttackCooldown;
    
    private void Awake() 
    {
        _currentAttackCooldown = _attackCooldown;   
    }

    private void FixedUpdate() 
    {
        if(_currentAttackCooldown == _attackCooldown) return;
        
        _currentAttackCooldown -= Time.fixedDeltaTime;
        
        if(_currentAttackCooldown <= 0)
        {
            _currentAttackCooldown = _attackCooldown;
        }
    }

    public void Attack()
    {
        if(_currentAttackCooldown != _attackCooldown) return;

        PlayAnim();
        _currentAttackCooldown -= Time.fixedDeltaTime;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _attackRadius, 1 << 6);

        for(int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].TryGetComponent<IDamageable>(out IDamageable enemy))
            {
                enemy.Damage(_damage);
            }
        }
    }

    private void PlayAnim()
    {
        _animator.SetTrigger("IsAttacking");
    }
}
