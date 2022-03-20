using TMPro;
using UnityEngine;

namespace CMC3D
{
    public class Multiplier : MonoBehaviour
    {
        [SerializeField] private int _multiplier;
        [SerializeField] private TextMeshProUGUI _screen;
        [SerializeField] private AmountChanger _amountChanger;

        private void Awake()
        {
            _amountChanger = GetComponentInParent<AmountChanger>();
            _screen.text = "* " + _multiplier;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Unit>(out Unit unit))
            {
                _amountChanger.Triggered.Invoke(unit.transform.parent.GetComponent<PlayerUnitsController>(), _multiplier);
            }
        }
    }
}
