using System.Collections;
using UnityEngine;

public class Enemy : Person
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected EnemyGroup _group;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _group = transform.parent.GetComponent<EnemyGroup>();
    }

    private void OnEnable()
    {
        _group.Attack += OnAttack;
    }

    private void OnDisable()
    {
        _group.Attack -= OnAttack;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Unit>(out Unit unit) &&
            unit.GetComponentInParent<PlayerGroup>().UnitsGroup.Contains(unit) &&
            _group.UnitsGroup.Contains(this))
        {
            _group.UnitsGroup.Remove(this);
            _group.Speed = unit.GetComponentInParent<PlayerGroup>().Speed;
            _group.Attack?.Invoke(unit.GetComponentInParent<PlayerGroup>().AverageUnitsPosition);
            unit.GetComponent<UnitAttack>().EnemyCollided(this);
            Destroy(gameObject);
        }
    }

    private void OnAttack(Vector3 target)
    {
        _group.Attack -= OnAttack;
        _animator.Play("Fast Run");
        StartCoroutine(Attack(target));
    }

    private IEnumerator Attack(Vector3 target)
    {
        while (true)
        {
            transform.LookAt(target);
            _rigidbody.velocity = _group.Speed * transform.forward;
            yield return null;
        }
    }
}