using System;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GroupStateMachine _group;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _group = transform.parent.GetComponent<GroupStateMachine>();
    }

    private void OnEnable()
    {
        _group.Run += Run;
        _group.Attack += Attack;
    }

    private void OnDisable()
    {
        _group.Run -= Run;
        _group.Attack -= Attack;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _speed * transform.forward;
    }

    private void Run()
    {
        transform.rotation = Quaternion.identity;
        Debug.Log(_rigidbody.velocity);
    }

    private void Attack(Vector3 target)
    {
        transform.LookAt(target);
        Debug.Log(_rigidbody.velocity);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _group.EnemyCollided = true;
            _group.AttackTarget = enemy.transform.position;
        }
    }
}
