using UnityEngine;

public class AttackTransition : Transition
{
    private GroupStateMachine _groupStateMachine;

    public override void Enable()
    {
        _groupStateMachine = GetComponent<GroupStateMachine>();
    }
    
    private void Update()
    {
        if(_groupStateMachine.EnemyCollided)
            NeedTransit = true;
    }
}
