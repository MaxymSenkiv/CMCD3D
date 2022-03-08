public class RunTransition : Transition
{
    private PlayerGroup _playerGroup;

    public override void Enable()
    {
        _playerGroup = GetComponent<PlayerGroup>();
    }
    
    private void Update()
    {
        if (_playerGroup.AttackTarget.GetComponent<EnemyGroup>().UnitsGroup.Count == 0)
            NeedTransit = true;
    }
}
