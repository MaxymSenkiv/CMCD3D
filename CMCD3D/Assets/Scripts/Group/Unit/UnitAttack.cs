using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Unit), typeof(UnitRun), typeof(BordersChecker))]
public class UnitAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerGroup _group;
    public UnityAction<Enemy> EnemyCollided;
    
    public bool _canAttack = true;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _group = transform.parent.GetComponent<PlayerGroup>();
        EnemyCollided += OnEnemyCollided;
    }
    
    public void Attack(Vector3 target)
    {
        transform.LookAt(target);
        if(_canAttack && transform.position != target)
            _rigidbody.velocity = _group.Speed * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Boss>(out Boss boss))
        {
            _canAttack = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _group.EnemyCollided = true;
            _group.AttackTarget = boss.transform.position;
        }
    }
    
    private void OnEnemyCollided(Enemy enemy)
    {
        _group.UnitsGroup.Remove(GetComponent<Unit>());
        if (!_group.EnemyCollided)
        {
            _group.Opponent = enemy.transform.parent.GetComponent<EnemyGroup>();
        }
        _group.EnemyCollided = true;
        Destroy(gameObject);
    }
}
