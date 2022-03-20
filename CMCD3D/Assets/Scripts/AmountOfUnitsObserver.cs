using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace CMC3D
{
    public class AmountOfUnitsObserver : MonoBehaviour
    {
        [FormerlySerializedAs("_group")] [SerializeField] private UnitsController _unitsController;
        [SerializeField] private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (_unitsController.UnitsGroup.Count == 0)
                Destroy(gameObject);
            _text.text = _unitsController.UnitsGroup.Count.ToString();
            transform.position = _unitsController.AverageUnitsPosition + Vector3.up * 5;
        }
    }
}
