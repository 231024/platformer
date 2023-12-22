using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveTree : MonoBehaviour
{
    [SerializeField] AppleTweener _apple;

    private void Start()
    {
        Instantiate(_apple, transform.position, transform.rotation);
    }
}
