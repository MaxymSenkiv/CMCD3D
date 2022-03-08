public class AttackTransition : Transition
{
    private PlayerGroup _playerGroup;

    public override void Enable()
    {
        _playerGroup = GetComponent<PlayerGroup>();
    }
    
    private void Update()
    {
        if (_playerGroup.EnemyCollided)
        {
            NeedTransit = true;
            _playerGroup.EnemyCollided = false;
        }
    }
}
