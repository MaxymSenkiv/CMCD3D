using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMC3D
{
    public abstract class UnitsController : MonoBehaviour 
    {
        [SerializeField] protected Transform _unit;
        public List<Person> UnitsGroup;
        [SerializeField] protected int _startAmount;
        public float Speed;

        [SerializeField] private float _groupingForce;
        [SerializeField] private float _groupingTime;
        [SerializeField] private int _timesOfGrouping;

        public Vector3 AverageUnitsPosition
        {
            get
            {
                Vector3 spawnPoint = new Vector3();
                if (UnitsGroup.Count != 0)
                {
                    foreach (var unit in UnitsGroup)
                    {
                        spawnPoint += unit.transform.position;
                    }

                    spawnPoint /= UnitsGroup.Count;
                }
                else
                {
                    spawnPoint = transform.position;
                }

                return spawnPoint;
            }
        }

        private void OnEnable()
        {
            UnitsMultiplier[] list = FindObjectsOfType<UnitsMultiplier>();
            foreach (UnitsMultiplier unitsMultiplier in list)
            {
                unitsMultiplier.UnitsCountChanged += OnUnitsCountChanged;
            }
        }

        private void OnUnitsCountChanged(int count)
        {
            SpawnUnits(count, AverageUnitsPosition, false);
        }

        private void Start()
        {
            // SpawnUnits(_startAmount, AverageUnitsPosition, false);
        }

        public void SpawnUnits(int amounts, Vector3 spawnPoint, bool run)
        {
            StartCoroutine(SpawnUnitsRoutine(_startAmount, AverageUnitsPosition, false));
        }
        
        private IEnumerator SpawnUnitsRoutine(int amounts, Vector3 spawnPoint, bool run)
        {
            for (int i = 0; i < amounts; i++)
            {
                spawnPoint = new Vector3(
                    spawnPoint.x + ((i % 4 - 1) % 2) * 1f,
                    spawnPoint.y,
                    spawnPoint.z + ((2 - i % 4) % 2) * 1f);
                Transform unit = Instantiate(_unit, spawnPoint, Quaternion.identity, transform);
                if (run)
                    unit.GetComponent<Animator>().Play("Fast Run");
                UnitsGroup.Add(unit.GetComponent<Person>());
                yield return new WaitForSeconds(0f / (amounts));
            }

            StartCoroutine(GroupUnits());
        }

        public IEnumerator GroupUnits()
        {
            for (int i = 0; i < _timesOfGrouping; i++)
            {
                foreach (var unit in UnitsGroup)
                {
                    Vector3 forceVector = new Vector3(
                        AverageUnitsPosition.x - unit.transform.position.x,
                        0,
                        AverageUnitsPosition.z - unit.transform.position.z);
                    unit.GetComponent<Rigidbody>().AddForce(forceVector * (_groupingForce / Mathf.Pow(2, i)));
                }

                yield return new WaitForSeconds(_groupingTime / _timesOfGrouping);
            }
        }
    }
}
