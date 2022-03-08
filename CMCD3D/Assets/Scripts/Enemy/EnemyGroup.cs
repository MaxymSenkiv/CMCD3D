using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGroup : Group<Enemy>
{
    public UnityAction<Vector3> Attack;
}