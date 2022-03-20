using System;
using UnityEngine;

public abstract class Person : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
