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

        if (LeftEdge)
            transform.position = new Vector3(-_borderLength, transform.position.y, transform.position.z);
        else if (RightEdge)
            transform.position =  new Vector3(_borderLength, transform.position.y, transform.position.z);
        
        
    }
}
