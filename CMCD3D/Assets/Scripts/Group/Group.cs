using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Group
{
    public abstract class Group : MonoBehaviour 
    {
        [SerializeField] protected Transform _unit;
        public List<Person> UnitsGroup;
        [SerializeField] protected int _startAmount;
        public float Speed;

        [SerializeField] private float _groupingForce;
        [SerializeField] private float _groupingTime;
        [SerializeField] private int _timesOfGrouping;

        public Vector3 SpawnPoint
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

        private void Awake()
        {
            StartCoroutine(SpawnUnits(_startAmount, SpawnPoint, false));
        }

        public IEnumerator SpawnUnits(int amounts, Vector3 spawnPoint, bool run)
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

        private IEnumerator GroupUnits()
        {
            for (int i = 0; i < _timesOfGrouping; i++)
            {
                foreach (var unit in UnitsGroup)
                {
                    Vector3 forceVector = new Vector3(
                        SpawnPoint.x - unit.transform.position.x,
                        0,
                        SpawnPoint.z - unit.transform.position.z);
                    unit.GetComponent<Rigidbody>().AddForce(forceVector * (_groupingForce / Mathf.Pow(2, i)));
                }

                yield return new WaitForSeconds(_groupingTime / _timesOfGrouping);
            }
        }
    }
}
