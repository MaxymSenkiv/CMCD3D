using UnityEngine;

public class PlayerGroup : Group<Unit>
{
    public Vector3 AttackTarget;
    public bool EnemyCollided;
    public float Speed;
}
