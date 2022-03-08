using System.Collections;
using UnityEngine;

public class EnemyStickman : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyGroup _group;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _group = transform.parent.GetComponent<EnemyGroup>();
    }

    private void OnEnable()
    {
        _group.Attack += OnAttack;
    }

    private void OnDisable()
    {
        _group.Attack -= OnAttack;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Stickman>(out Stickman stickman))
        {
            _group.EnemyCollided = true;
            _group.Attack?.Invoke(stickman.transform.position);
            Destroy(gameObject);
        }
    }

    private void OnAttack(Vector3 target)
    {
        _animator.Play("Fast Run");
        StartCoroutine(Attack(target));
    }

    public IEnumerator Attack(Vector3 target)
    {
        while (true)
        {
            transform.LookAt(target);
            _rigidbody.velocity = _speed * transform.forward;
            yield return null;
        }
    }
}