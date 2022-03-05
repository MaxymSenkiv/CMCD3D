using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGroup : Group<Stickman>
{
    public UnityAction<Vector3> Attack;
    public Vector3 AttackTarget;
    public bool EnemyCollided;
}
