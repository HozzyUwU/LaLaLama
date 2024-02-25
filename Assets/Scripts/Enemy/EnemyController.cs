using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public byte Health => _currentHealth;

    [Header("References")]
    [Space]
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;

    [Header("Properties")]
    [Space]
    [Range(0, 255)]
    [SerializeField] private byte _maxHealth;
    [SerializeField] private string _itemWord;
    private bool _isDead;
    
    byte _currentHealth;

    private void Awake() 
    {
        _isDead = false;
        _currentHealth = _maxHealth;    
    }

    public void Damage(byte damage)
    {
        if(_isDead) return;

        StartCoroutine(DamageEffectCo());
        Debug.Log($"I was damaged by player with {damage}");
        
        _currentHealth = _currentHealth <= damage ? Death() : _currentHealth -= damage;
    }

    private byte Death()
    {
        Debug.Log($"Dead!");
        _isDead = true;
        PlayAnim();

        // _collider.enabled = false;

        StartCoroutine(DropItemCo());

        // gameObject.SetActive(false);
        return 0;
    }

    private IEnumerator DropItemCo()
    {
        yield return new WaitForSeconds(1.8f);
        _itemPrefab.ItemName = _itemWord;
        Instantiate(_itemPrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator DamageEffectCo()
    {
        _sprite.color = Color.red;

        yield return new WaitForSeconds(0.3f);

        _sprite.color = Color.white;
    }

    private void PlayAnim()
    {
        _animator.SetTrigger("Death");
    }
}
