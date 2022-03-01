using UnityEngine;

public class RunState : State
{
    private GroupStateMachine _groupStateMachine;

    private void Awake()
    {
        _groupStateMachine = GetComponent<GroupStateMachine>();
    }

    private void FixedUpdate()
    {
        _groupStateMachine.Run?.Invoke();
    }
}
