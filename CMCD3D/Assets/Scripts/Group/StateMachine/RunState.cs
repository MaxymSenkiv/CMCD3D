using System;
using UnityEngine;

public class RunState : State
{
    private PlayerGroup _playerGroup;

    private void Awake()
    {
        _playerGroup = GetComponent<PlayerGroup>();
    }

    private void OnEnable()
    {
        foreach (var unit in _playerGroup.UnitsGroup)
        {
            unit.GetComponent<Animator>().Play("Fast Run");
        }
    }

    private void FixedUpdate()
    {
        foreach (var unit in _playerGroup.UnitsGroup)
        {
            unit.GetComponent<UnitRun>().Run();
        }
    }
}
