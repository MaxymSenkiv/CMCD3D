using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private GroupStateMachine _groupStateMachine;

    private void Awake()
    {
        _groupStateMachine = GetComponent<GroupStateMachine>();
    }

    private void OnEnable()
    {
        Debug.Log("Attack");
        _groupStateMachine.Attack?.Invoke(_groupStateMachine.AttackTarget);
    }
}
