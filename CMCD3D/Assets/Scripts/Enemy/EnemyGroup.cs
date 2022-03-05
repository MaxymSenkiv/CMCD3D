using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGroup : Group<EnemyStickman>
{
    public UnityAction<Vector3> Attack;
    public bool EnemyCollided;
}