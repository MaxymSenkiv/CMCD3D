using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _maxDamage;
    [SerializeField] private int _attackDistance;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Stickman stickman))
        {
            Attack(collision.transform.parent.GetComponent<PlayerGroup>());
        }
    }

    private void Attack(PlayerGroup playerGroup)
    {
        List<Stickman> deadUnits = new List<Stickman>();
        foreach (var stickman in playerGroup._unitsGroup)
        {
            if (Vector3.Distance(transform.position, stickman.transform.position) < _attackDistance 
                && deadUnits.Count < _maxDamage)
            {
                deadUnits.Add(stickman);
            }
        }

        foreach (var unit in deadUnits)
        {
            unit.Died?.Invoke();
        }
    }
}
