using System;
using UnityEngine;

namespace CMC3D
{
    public class UnitsMultiplier : MonoBehaviour
    {
        [SerializeField] private Collider _secondCollider;
        [SerializeField] private int _multiplier;
        
        public event Action<int> UnitsCountChanged;

        private void OnTriggerEnter(Collider other)
        {
            // if unit

            UnitsCountChanged?.Invoke(_multiplier);
            _secondCollider.enabled = false;
        }
    }
}