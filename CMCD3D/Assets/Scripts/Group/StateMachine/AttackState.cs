public class AttackState : State
{
    private PlayerGroup _playerGroup;

    private void Awake()
    {
        _playerGroup = GetComponent<PlayerGroup>();
    }

    private void Update()
    {
        foreach (var unit in _playerGroup.UnitsGroup)
        {
            unit.GetComponent<UnitAttack>().Attack(_playerGroup.AttackTarget.position);
        }
    }
}
