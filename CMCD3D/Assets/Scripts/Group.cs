using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGroup : MonoBehaviour
{
    [SerializeField] protected Transform _unit;
    [SerializeField] protected int _startAmount;
    [SerializeField] protected float _spawnDistance;

    protected void SpawnUnits(int amounts)
    {
        for (int i = 0; i < amounts; i++)
        {
            if (i % 4 == 0 && i > 0)
                _spawnDistance += 1.5f;
            Vector3 spawnPoint = new Vector3(
                transform.position.x + ((i%4-1)%2) * _spawnDistance, 
                transform.position.y,
                transform.position.z + ((2 - i%4)%2) * _spawnDistance);
            Instantiate(_unit, spawnPoint, Quaternion.identity, transform);
        }
    }
}
