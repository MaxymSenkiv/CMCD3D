using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(UnitAttack))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private PlayerGroup _playerGroup;
    public UnityAction Died;
    public UnityAction ObstacleCollided;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
        _playerGroup = transform.parent.GetComponent<PlayerGroup>();
        
        Died += OnDied;
        ObstacleCollided += OnObstacleCollided;
    }

    private void OnDied()
    {
        _playerGroup.UnitsGroup.Remove(this);
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

    private void OnObstacleCollided()
    {
        _playerGroup.UnitsGroup.Remove(this);
        Destroy(gameObject);
    }
}
