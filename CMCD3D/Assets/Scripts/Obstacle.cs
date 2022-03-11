using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.gameObject.TryGetComponent<Unit>(out Unit unit))
        {
            unit.ObstacleCollided.Invoke();
        }
    }
}
