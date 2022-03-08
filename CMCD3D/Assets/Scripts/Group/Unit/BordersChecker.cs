using UnityEngine;

[RequireComponent(typeof(Unit), typeof(UnitRun), typeof(UnitAttack))]
public class BordersChecker : MonoBehaviour
{
    [SerializeField] private int _borderLength;
    public bool LeftEdge;
    public bool RightEdge;
    
    void Update()
    {
        LeftEdge = transform.position.x <= -_borderLength;
        RightEdge = transform.position.x >= _borderLength;
    }
}
