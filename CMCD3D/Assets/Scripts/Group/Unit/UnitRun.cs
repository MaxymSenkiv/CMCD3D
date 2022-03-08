using UnityEngine;

[RequireComponent(typeof(Unit), typeof(UnitAttack), typeof(BordersChecker))]
public class UnitRun : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerGroup _playerGroup;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerGroup = transform.parent.GetComponent<PlayerGroup>();
    }

    public void Run()
    {
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = _playerGroup.Speed * transform.forward;
    }
    
}
