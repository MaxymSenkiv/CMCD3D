using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroupStateMachine : StateMachine
{
    [SerializeField] private List<Stickman> _stickmans;
    public UnityAction Run;
    public UnityAction<Vector3> Attack;
    public Vector3 AttackTarget;
    public bool EnemyCollided;
    
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent(out Stickman stickman))
                _stickmans.Add(stickman);
        }
    }
}
