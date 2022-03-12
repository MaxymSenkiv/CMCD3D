using TMPro;
using UnityEngine;

public class AmountOfUnitsObserver : MonoBehaviour
{
    [SerializeField] private Group.Group _group;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_group.UnitsGroup.Count == 0)
            Destroy(gameObject);
        _text.text = _group.UnitsGroup.Count.ToString();
        transform.position = _group.SpawnPoint + Vector3.up * 5;
    }
}
