using UnityEngine;

public class RunState : State
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
            unit.GetComponent<UnitRun>().Run();
        }
    }
}
