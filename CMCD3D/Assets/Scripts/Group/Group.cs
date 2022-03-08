using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Group<T> : MonoBehaviour
{
    [SerializeField] protected Transform _unit;
    public List<T> UnitsGroup;
    [SerializeField] protected int _startAmount;
    
    private void Awake()
    {
        StartCoroutine(SpawnUnits(_startAmount, transform.position, false));
    }

    public IEnumerator SpawnUnits(int amounts, Vector3 spawnPoint, bool run)
    {
        for (int i = 0; i < amounts; i++)
        {
            Transform unit = Instantiate(_unit, spawnPoint, Quaternion.identity, transform);
            if(run)
                unit.GetComponent<Animator>().Play("Fast Run");
            UnitsGroup.Add(unit.GetComponent<T>());
            yield return new WaitForSeconds(0.1f/(amounts-1));
        }
    }
}
