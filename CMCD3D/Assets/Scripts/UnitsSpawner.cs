using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CMCD3D
{
    public class UnitsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private int _count;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Transform _parentTransform;

        private List<Transform> _units = new List<Transform>();
        private int _currentUnitIndex = -1;

        private void OnDrawGizmos()
        {
            Bounds bounds = GetUnitsBounds();

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(bounds.center, 0.25f);
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            for (int i = 0; i < _count; i++)
            {
                Transform spawnPoint = _spawnPoints[GetNextSpawnPointIndex()];
                Transform unit = Instantiate(_unitPrefab, spawnPoint).transform;
                unit.SetParent(_parentTransform);

                _units.Add(unit);
                yield return null;
            }
        }

        private int GetNextSpawnPointIndex()
        {
            _currentUnitIndex++;

            if (_currentUnitIndex >= _spawnPoints.Length)
            {
                _currentUnitIndex = 0;
            }

            return _currentUnitIndex;
        }

        private Bounds GetUnitsBounds()
        {
            Bounds bounds = new Bounds();
            
            if (_units.Count > 0)
            {
                bounds = new Bounds(_units[0].position, Vector3.zero);
                foreach (Transform unit in _units)
                {
                    bounds.Encapsulate(unit.position);
                }
            }

            return bounds;
        }
    }
}