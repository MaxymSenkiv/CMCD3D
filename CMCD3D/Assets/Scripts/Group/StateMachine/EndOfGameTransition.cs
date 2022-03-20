public class EndOfGameTransition : Transition
{
    private PlayerUnitsController _unitsController;
    
    private void Awake()
    {
        _unitsController = GetComponent<PlayerUnitsController>();
    }

    private void Update()
    {
        if (_unitsController.UnitsGroup.Count == 0)
            NeedTransit = true;
    }
    
    public override void Enable()
    {
    }
}
