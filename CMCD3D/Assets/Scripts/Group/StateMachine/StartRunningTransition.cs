using UnityEngine;

public class StartRunningTransition : Transition
{
    public override void Enable()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            NeedTransit = true;
    }
}
