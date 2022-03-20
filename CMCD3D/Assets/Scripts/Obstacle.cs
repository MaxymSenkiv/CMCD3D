using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public event Action ObstacleCollided;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.gameObject.TryGetComponent<Unit>(out Unit unit))
        {
            ObstacleCollided?.Invoke();
        }
    }
}
