using UnityEngine;
using UnityEngine.Events;

public class EnemyGroup : Group<Enemy>
{
    public UnityAction<Vector3> Attack;
}