using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(UnitAttack))]
public class Unit : Person
{
    [SerializeField] private SphereCollider _collider;
    [FormerlySerializedAs("_group")] [SerializeField] private PlayerUnitsController _unitsController;
    public event UnityAction Died;
    public event UnityAction ObstacleCollided;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _unitsController = transform.parent.GetComponent<PlayerUnitsController>();
        
        Died += OnDied;
        ObstacleCollided += OnObstacleCollided;
    }

    private void OnDied()
    {
        _unitsController.UnitsGroup.Remove(this);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.constraints = RigidbodyConstraints.None;
        _collider.enabled = false;
        
        Vector3 explosionPosition = transform.position + Vector3.forward + Vector3.down;
        _rigidbody.AddExplosionForce(150f, explosionPosition, 3f,0.25f, ForceMode.Impulse);
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        // if ostacle
    }

    private void OnObstacleCollided()
    {
        _unitsController.UnitsGroup.Remove(this);
        Destroy(gameObject);
    }
}
