using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private PlayerGroup _group;
    [SerializeField] private Vector3 _target;
    [SerializeField] private Vector3 _offset;

    void Update()
    {
        FollowUnits();
    }

    private void FollowUnits()
    {
        if (_group._unitsGroup.Count != 0)
        {
            _target = _group._unitsGroup[0].transform.position;
            transform.position = new Vector3(transform.position.x,
                _target.y + _offset.y,
                _target.z + _offset.z);
        }
    }
}
