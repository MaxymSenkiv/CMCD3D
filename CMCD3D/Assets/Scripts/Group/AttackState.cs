using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private PlayerGroup _playerGroup;

    private void Awake()
    {
        _playerGroup = GetComponent<PlayerGroup>();
    }

    private void FixedUpdate()
    {
        foreach (var unit in _playerGroup._unitsGroup)
        {
            unit.Attack(_playerGroup.AttackTarget);
        }
    }
}
