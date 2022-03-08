using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(UnitAttack))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private PlayerGroup _playerGroup;
    public UnityAction Died;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<SphereCollider>();
        _playerGroup = transform.parent.GetComponent<PlayerGroup>();
        
        Died += OnDied;
        
        _animator.Play("Fast Run");
    }

    

    private void OnDied()
    {
        _playerGroup._unitsGroup.Remove(this);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.freezeRotation = false;
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
}
