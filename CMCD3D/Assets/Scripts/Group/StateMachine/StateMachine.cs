using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_rigidbody, _animator);
    }
}
