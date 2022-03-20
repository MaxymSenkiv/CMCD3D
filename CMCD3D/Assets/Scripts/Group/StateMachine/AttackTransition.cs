public class AttackTransition : Transition
{
    private PlayerUnitsController _playerUnitsController;

    public override void Enable()
    {
        _playerUnitsController = GetComponent<PlayerUnitsController>();
    }
    
    private void Update()
    {
        if (_playerUnitsController.EnemyCollided)
        {
            NeedTransit = true;
            _playerUnitsController.EnemyCollided = false;
        }
    }
}
