public class EndOfGameTransition : Transition
{
    private PlayerGroup _group;
    
    private void Awake()
    {
        _group = GetComponent<PlayerGroup>();
    }

    private void Update()
    {
        if (_group.UnitsGroup.Count == 0)
            NeedTransit = true;
    }
    
    public override void Enable()
    {
    }
}
