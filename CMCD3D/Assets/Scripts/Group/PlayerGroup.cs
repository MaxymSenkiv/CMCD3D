using UnityEngine;

public class PlayerGroup : Group<Stickman>
{
    public Vector3 AttackTarget;
    public bool EnemyCollided;
    public float Speed;
}
