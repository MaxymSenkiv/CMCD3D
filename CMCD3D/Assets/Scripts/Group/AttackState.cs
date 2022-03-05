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

    private void OnEnable()
    {
        _playerGroup.Attack?.Invoke(_playerGroup.AttackTarget);
    }
}
