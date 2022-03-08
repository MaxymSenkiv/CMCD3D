using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Group<T> : MonoBehaviour
{
    [SerializeField] protected Transform _unit;
    [SerializeField] public List<T> _unitsGroup;
    [SerializeField] protected int _startAmount;
    [SerializeField] protected float _spawnDistance;
    
    private void Awake()
    {
        StartCoroutine(SpawnUnits(_startAmount));
    }

    public IEnumerator SpawnUnits(int amounts)
    {
        for (int i = 0; i < amounts; i++)
        {
            //if (i % 4 == 0 && i > 0)
                //_spawnDistance += 3f;
            Vector3 spawnPoint = new Vector3(
                transform.position.x + ((i%4-1)%2) * _spawnDistance, 
                transform.position.y,
                transform.position.z + ((2 - i%4)%2) * _spawnDistance);
            Transform unit = Instantiate(_unit, spawnPoint, Quaternion.identity, transform);
            _unitsGroup.Add(unit.GetComponent<T>());
            yield return new WaitForSeconds(1f/(amounts-1));
        }
    }
}
