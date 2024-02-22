using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProvider : MonoBehaviour, IAttackProvider
{
    [Header("Properties")]
    [Space]
    [Range(1.0f, 2.0f)]
    [SerializeField] private float _attackRadius;
    [SerializeField] private byte _damage;
    
    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _attackRadius, 1 << 6);

       for(int i = 0; i < enemies.Length; i++)
       {
            if(enemies[i].TryGetComponent<IDamageable>(out IDamageable enemy))
            {
                enemy.Damage(_damage);
            }
       }
    }
}
