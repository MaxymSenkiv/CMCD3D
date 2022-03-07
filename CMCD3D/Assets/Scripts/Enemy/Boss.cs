using System;
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
        if (collision.gameObject.TryGetComponent(out Stickman stickman) && !_attack)
        {
            StartCoroutine(Attack(collision.transform.parent.GetComponent<PlayerGroup>()));
        }
    }

    private IEnumerator Attack(PlayerGroup playerGroup)
    {
        _attack = true;
        _animator.Play("Kick");
        while (true)
        {
            List<Stickman> deadUnits = new List<Stickman>();
            yield return new WaitForSeconds(0.5f);
            foreach (var stickman in playerGroup._unitsGroup)
            {
                if (Vector3.Distance(transform.position, stickman.transform.position) < _attackDistance
                    && deadUnits.Count < _maxDamage)
                {
                    deadUnits.Add(stickman);
                }
            }

            foreach (var unit in deadUnits)
            {
                unit.Died?.Invoke();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
