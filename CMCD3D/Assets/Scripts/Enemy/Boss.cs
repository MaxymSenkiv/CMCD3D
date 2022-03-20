using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _maxDamage;
    [SerializeField] private int _attackDistance;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _attack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Unit unit) && !_attack)
        {
            StartCoroutine(Attack(collision.transform.parent.GetComponent<PlayerUnitsController>()));
        }
    }

    private IEnumerator Attack(PlayerUnitsController playerUnitsController)
    {
        _attack = true;
        _animator.Play("Kick");
        while (true)
        {
            List<Unit> deadUnits = new List<Unit>();
            yield return new WaitForSeconds(0.5f);
            foreach (var unit in playerUnitsController.UnitsGroup)
            {
                if (Vector3.Distance(transform.position, unit.transform.position) < _attackDistance
                    && deadUnits.Count < _maxDamage)
                {
                    deadUnits.Add((Unit)unit);
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
