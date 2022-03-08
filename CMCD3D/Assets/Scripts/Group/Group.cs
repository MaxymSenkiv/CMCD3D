using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Group<T> : MonoBehaviour
{
    [SerializeField] protected Transform _unit;
    public List<T> UnitsGroup;
    [SerializeField] protected int _startAmount;
    [SerializeField] protected float _spawnDistance;
    
    private void Awake()
    {
        StartCoroutine(SpawnUnits(_startAmount, false));
    }

    public IEnumerator SpawnUnits(int amounts, bool run)
    {
        for (int i = 0; i < amounts; i++)
        {
            if (i % 4 == 0 && i > 0)
                _spawnDistance += 0.5f;
            
            Vector3 spawnPoint = new Vector3(
                transform.position.x + ((i%4-1)%2) * _spawnDistance, 
                transform.position.y,
                transform.position.z + ((2 - i%4)%2) * _spawnDistance);
            Transform unit = Instantiate(_unit, spawnPoint, Quaternion.identity, transform);
            if(run)
                unit.GetComponent<Animator>().Play("Fast Run");
            UnitsGroup.Add(unit.GetComponent<T>());
            yield return new WaitForSeconds(0.1f/(amounts-1));
        }
    }

    private void Update()
    {
        Debug.Log(gameObject.GetComponent<Transform>().position);
    }
}