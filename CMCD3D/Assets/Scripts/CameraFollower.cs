using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private PlayerGroup _group;
    [SerializeField] private float _offsetZ;

    private void Awake()
    {
        _offsetZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (_group.UnitsGroup.Count == 0)
        {
            enabled = false;
            return;
        }

        transform.position = new Vector3(transform.position.x,
            transform.position.y,
            _group.AverageUnitsPosition.z + _offsetZ);
    }
}
