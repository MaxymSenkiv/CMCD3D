using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyGroup : IGroup
    {
        [SerializeField] private List<EnemyStickman> _enemyStickmans;
        public UnityAction<Vector3> Attack;
        public bool EnemyCollided;

        private void Awake()
        {
            SpawnUnits(_startAmount);
        }

        private void Start()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.TryGetComponent(out EnemyStickman enemyStickman))
                    _enemyStickmans.Add(enemyStickman);
            }
        }
    }
}