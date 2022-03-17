using UnityEngine;

public class EndOfGameTransition : Transition
{
    private PlayerGroup _group;
    [SerializeField] private CameraFollower _cameraFollower;

    private void Awake()
    {
        _group = GetComponent<PlayerGroup>();
    }

    private void Update()
    {
        if (_group.UnitsGroup.Count == 0)
        {
            _cameraFollower.enabled = false;
            NeedTransit = true;
        }
    }
    
    public override void Enable()
    {
    }
}
