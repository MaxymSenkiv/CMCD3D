using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    
    void Update()
    {
        transform.position = _target.position + _offset;
    }
}