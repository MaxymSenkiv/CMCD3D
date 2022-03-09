using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private PlayerGroup _group;
    [SerializeField] private float _offsetZ;

    private void Awake()
    {
        _offsetZ = transform.position.z;
    }

    void Update()
    {
        FollowUnits();
    }

    private void FollowUnits()
    {
        transform.position = new Vector3(transform.position.x,
                                        transform.position.y,
                                        _group.SpawnPoint.z + _offsetZ);
    }
}
