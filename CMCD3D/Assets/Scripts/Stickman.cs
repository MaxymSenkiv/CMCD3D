using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Stickman : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private PlayerGroup _playerGroup;
    [SerializeField] private float _speed;
    public UnityAction Died;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _playerGroup = transform.parent.GetComponent<PlayerGroup>();
        Died += OnDied;
    }

    private void OnEnable()
    {
        _playerGroup.Attack += OnAttack;
    }

    private void OnDisable()
    {
        _playerGroup.Attack -= OnAttack;
    }

    public void Run()
    {
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = _speed * transform.forward;
    }

    private void OnAttack(Vector3 target)
    {
        StartCoroutine(Attack(target));
    }

    public IEnumerator Attack(Vector3 target)
    {
        while (true)
        {
            transform.LookAt(target);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyStickman>(out EnemyStickman enemy))
        {
            _playerGroup.EnemyCollided = true;
            _playerGroup.AttackTarget = enemy.transform.position;
            Destroy(gameObject);
        }
    }

    private void OnDied()
    {
        _playerGroup._unitsGroup.Remove(this);
        _rigidbody.velocity = Vector3.zero;
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
