using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Damage : MonoBehaviour
{
    [SerializeField] private float amountDamage;
    [SerializeField] private AnimationClip _hitAnimation;

    public float AmountDamage => amountDamage;

    void Start()
    {
        Destroy(gameObject, _hitAnimation.length);
    }
}
