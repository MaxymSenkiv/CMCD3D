public class RunTransition : Transition
{
    private PlayerUnitsController _playerUnitsController;

    public override void Enable()
    {
        _playerUnitsController = GetComponent<PlayerUnitsController>();
    }
    
    private void Update()
    {
        if (_playerUnitsController.Opponent != null 
            && _playerUnitsController.Opponent.UnitsGroup.Count == 0)
            NeedTransit = true;
    }
}
