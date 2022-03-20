using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Unit), typeof(UnitRun), typeof(BordersChecker))]
public class UnitAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [FormerlySerializedAs("_group")] [SerializeField] private PlayerUnitsController _unitsController;
    public UnityAction<Enemy> EnemyCollided;
    
    public bool _canAttack = true;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _unitsController = transform.parent.GetComponent<PlayerUnitsController>();
        EnemyCollided += OnEnemyCollided;
    }
    
    public void Attack(Vector3 target)
    {
        transform.LookAt(target);
        if(_canAttack && transform.position != target)
            _rigidbody.velocity = _unitsController.Speed * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Boss>(out Boss boss))
        {
            _canAttack = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _unitsController.EnemyCollided = true;
            _unitsController.AttackTarget = boss.transform.position;
        }
    }
    
    private void OnEnemyCollided(Enemy enemy)
    {
        _unitsController.UnitsGroup.Remove(GetComponent<Unit>());
        if (!_unitsController.EnemyCollided)
        {
            _unitsController.Opponent = enemy.transform.parent.GetComponent<EnemyUnitsController>();
        }
        _unitsController.EnemyCollided = true;
        Destroy(gameObject);
    }
}
