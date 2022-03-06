using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Stickman : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private PlayerGroup _playerGroup;
    public UnityAction Died;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _playerGroup = transform.parent.GetComponent<PlayerGroup>();
        
        Died += OnDied;
    }

    public void Run()
    {
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = _playerGroup.Speed * transform.forward;
    }

    public void Attack(Vector3 target)
    {
        _rigidbody.velocity = _playerGroup.Speed * transform.forward;
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyStickman>(out EnemyStickman enemy))
        {
            _playerGroup.EnemyCollided = true;
            _playerGroup._unitsGroup.Remove(this);
            _playerGroup.AttackTarget = enemy.transform.position;
            
            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent<Boss>(out Boss boss))
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _playerGroup.EnemyCollided = true;
            _playerGroup.AttackTarget = boss.transform.position;
        }
    }

    private void OnDied()
    {
        _playerGroup._unitsGroup.Remove(this);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.freezeRotation = false;
        _capsuleCollider.enabled = false;
        
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
