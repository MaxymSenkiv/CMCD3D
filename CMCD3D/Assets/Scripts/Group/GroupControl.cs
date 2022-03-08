using UnityEngine;

public class GroupControl : MonoBehaviour
{
    [SerializeField] private PlayerGroup _group;
    [SerializeField] private float _roadWidth;
    [SerializeField] private Vector3 _lastMousePosition;
    [SerializeField] private float _delta;

    private void Start()
    {
        _group = GetComponent<PlayerGroup>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePosition = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
        {
            _delta = (Input.mousePosition.x - _lastMousePosition.x) / (Screen.width / _roadWidth);
            
            if ((_delta > 0 && !CanMoveRight()) || (_delta < 0 && !CanMoveLeft()))
                return;
            
            transform.position = new Vector3(transform.position.x + _delta,
                                                transform.position.y,
                                                transform.position.z);
            _lastMousePosition = Input.mousePosition;
        }
    }

    private bool CanMoveLeft()
    {
        foreach (var unit in _group.UnitsGroup)
        {
            if (unit.GetComponent<BordersChecker>().LeftEdge)
                return false;
        }

        return true;
    }
    
    private bool CanMoveRight()
    {
        foreach (var unit in _group.UnitsGroup)
        {
            if (unit.GetComponent<BordersChecker>().RightEdge)
                return false;
        }

        return true;
    }
}
