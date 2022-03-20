using System;
using UnityEngine;

public class RunState : State
{
    private PlayerUnitsController _playerUnitsController;

    private void Awake()
    {
        _playerUnitsController = GetComponent<PlayerUnitsController>();
    }

    private void OnEnable()
    {
        StartCoroutine(_playerUnitsController.GroupUnits());
        foreach (var unit in _playerUnitsController.UnitsGroup)
        {
            unit.GetComponent<Animator>().Play("Fast Run");
        }
    }

    private void FixedUpdate()
    {
        foreach (var unit in _playerUnitsController.UnitsGroup)
        {
            unit.GetComponent<UnitRun>().Run();
        }
    }
}
