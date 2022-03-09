using UnityEngine;

public class PlayerGroup : Group<Unit>
{
    public Transform AttackTarget;
    public bool EnemyCollided;
    public float Speed;
}
