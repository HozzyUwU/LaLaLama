using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaScreamer : MonoBehaviour
{

    [Header("References")]
    [Space]
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;
    [SerializeField] private MenuController _menu;

    public void Screamer() 
    {
        _animator.SetBool("IsScreamer", true);

        StartCoroutine(ScremerCo());
    }

    private IEnumerator ScremerCo()
    {
        _menu.PauseState(true);
        _sprite.sortingOrder = 2;

        yield return new WaitForSeconds (3.0f);

        _menu.PauseState(false);
        _animator.SetBool("IsScreamer", false);
        _sprite.sortingOrder = 0;
    }
}
