using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private PlayerGroup _group;
    [SerializeField] private float _target;
    [SerializeField] private Vector3 _offset;

    void Update()
    {
        FollowUnits();
    }

    private void FollowUnits()
    {
        if (_group.UnitsGroup.Count != 0)
        {
            foreach (var unit in _group.UnitsGroup)
            {
                _target += unit.transform.position.z;
            }
            _target /= _group.UnitsGroup.Count;
            
            transform.position = new Vector3(transform.position.x,
                _offset.y,
                _target + _offset.z);
        }
    }
}
