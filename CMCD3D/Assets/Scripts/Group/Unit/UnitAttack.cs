using UnityEngine;

[RequireComponent(typeof(Unit), typeof(UnitRun), typeof(BordersChecker))]
public class UnitAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerGroup _playerGroup;
    
    public bool _canAttack = true;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerGroup = transform.parent.GetComponent<PlayerGroup>();
    }
    
    public void Attack(Vector3 target)
    {
        transform.LookAt(target);
        if(_canAttack)
            _rigidbody.velocity = _playerGroup.Speed * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _playerGroup.EnemyCollided = true;
            _playerGroup.AttackTarget = enemy.transform.parent.transform;

            GetComponent<Unit>().ObstacleCollided.Invoke();
        }
        else if (collision.gameObject.TryGetComponent<Boss>(out Boss boss))
        {
            _canAttack = false;
            //_rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _playerGroup.EnemyCollided = true;
            _playerGroup.AttackTarget = boss.transform;
        }
    }
}
