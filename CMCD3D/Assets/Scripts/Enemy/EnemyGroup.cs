using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyGroup : MonoBehaviour
    {
        [SerializeField] private List<EnemyStickman> _enemyStickmans;
        public UnityAction<Vector3> Attack;
        public bool EnemyCollided;

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.TryGetComponent(out EnemyStickman enemyStickman))
                    _enemyStickmans.Add(enemyStickman);
            }
        }
    }
}