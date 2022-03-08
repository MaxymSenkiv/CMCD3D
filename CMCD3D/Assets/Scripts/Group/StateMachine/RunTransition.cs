public class RunTransition : Transition
{
    private PlayerGroup _playerGroup;

    public override void Enable()
    {
        _playerGroup = GetComponent<PlayerGroup>();
    }
    
    private void Update()
    {
        if (_playerGroup.AttackTarget.TryGetComponent<EnemyGroup>(out EnemyGroup enemyGroup) 
            && enemyGroup.UnitsGroup.Count == 0)
            NeedTransit = true;
    }
}
