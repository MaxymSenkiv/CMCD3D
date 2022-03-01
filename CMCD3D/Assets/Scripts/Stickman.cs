using UnityEngine;
using Enemy;
using System.Collections;

public class Stickman : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GroupStateMachine _group;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _group = transform.parent.GetComponent<GroupStateMachine>();
    }

    private void OnEnable()
    {
        _group.Run += Run;
        _group.Attack += OnAttack;
    }

    private void OnDisable()
    {
        _group.Run -= Run;
        _group.Attack -= OnAttack;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _speed * transform.forward;
    }

    private void Run()
    {
        transform.rotation = Quaternion.identity;
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
            _group.EnemyCollided = true;
            _group.AttackTarget = enemy.transform.position;
            Destroy(gameObject);
        }
    }
}
