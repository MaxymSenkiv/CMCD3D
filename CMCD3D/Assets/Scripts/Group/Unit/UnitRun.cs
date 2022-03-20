using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Unit), typeof(UnitAttack), typeof(BordersChecker))]
public class UnitRun : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [FormerlySerializedAs("_playerGroup")] [SerializeField] private PlayerUnitsController _playerUnitsController;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerUnitsController = transform.parent.GetComponent<PlayerUnitsController>();
    }

    public void Run()
    {
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = _playerUnitsController.Speed * transform.forward;
    }
    
}
