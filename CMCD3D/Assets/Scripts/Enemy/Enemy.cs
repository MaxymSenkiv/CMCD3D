using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : Person
{
    [SerializeField] protected Animator _animator;
    [FormerlySerializedAs("_group")] [SerializeField] protected EnemyUnitsController _unitsController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _unitsController = transform.parent.GetComponent<EnemyUnitsController>();
    }

    private void OnEnable()
    {
        _unitsController.Attack += OnAttack;
    }

    private void OnDisable()
    {
        _unitsController.Attack -= OnAttack;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Unit>(out Unit unit) &&
            unit.GetComponentInParent<PlayerUnitsController>().UnitsGroup.Contains(unit) &&
            _unitsController.UnitsGroup.Contains(this))
        {
            _unitsController.UnitsGroup.Remove(this);
            _unitsController.Speed = unit.GetComponentInParent<PlayerUnitsController>().Speed;
            _unitsController.Attack?.Invoke(unit.GetComponentInParent<PlayerUnitsController>());
            unit.GetComponent<UnitAttack>().EnemyCollided(this);
            Destroy(gameObject);
        }
    }

    private void OnAttack(PlayerUnitsController playerUnitsController)
    {
        _unitsController.Attack -= OnAttack;
        _animator.Play("Fast Run");
        StartCoroutine(Attack(playerUnitsController));
    }

    private IEnumerator Attack(PlayerUnitsController playerUnitsController)
    {
        while (transform.position != playerUnitsController.AverageUnitsPosition)
        {
            transform.LookAt(playerUnitsController.AverageUnitsPosition);
            _rigidbody.velocity = _unitsController.Speed * transform.forward;
            yield return null;
        }
    }
}