using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthBandit : MonoBehaviour
{
    [SerializeField] private float _amountHealth = 0.0f;
    [SerializeField] private Animator _animator;

    private string _animationHurt = "Hurt";
    private string _animationDeath = "Death";


    void Update()
    {
        if(_amountHealth <= 0.0f)
        {
            PlayDeathAnimation();
            Destroy(gameObject, 3);
        }
    }

    private void DecreaseHealth(float _damage) 
    {
        _amountHealth -= _damage;
    }

    private void PlayHurthAnimation() 
    {
        _animator.SetTrigger(_animationHurt);
    }

    private void PlayDeathAnimation() 
    {
        _animator.SetTrigger(_animationDeath);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DecreaseHealth(10.0f);
        PlayHurthAnimation();
    }
}
