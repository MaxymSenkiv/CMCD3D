using UnityEngine;

public class PlayerGroup : Group<Unit>
{
    public Transform AttackTarget;
    public bool EnemyCollided;
    public float Speed;
    
    public Vector3 SpawnPoint {
        get {
            Vector3 spawnPoint = new Vector3();
            foreach (var unit in UnitsGroup)
            {
                spawnPoint += unit.transform.position;
            }

            spawnPoint /= UnitsGroup.Count;

            return spawnPoint;
        }
    }
}
