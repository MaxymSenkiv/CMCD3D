using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollower : MonoBehaviour
{
    [FormerlySerializedAs("_group")] [SerializeField] private PlayerUnitsController _unitsController;
    private Vector3 _offset;

    [SerializeField] private Transform _targetTransform;

    private bool _isFollowing;
    private Level _level;

    private void Awake()
    {
        _offset = transform.position;
    }

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _level.LevelStarted += StartFollowing;
    }

    private void LateUpdate()
    {
        if (_isFollowing)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        transform.position = _targetTransform.position + _offset;
    }
    
    public void StartFollowing()
    {
        _isFollowing = true;
    }

    public void EndFollowing()
    {
        _isFollowing = false;
    }
}