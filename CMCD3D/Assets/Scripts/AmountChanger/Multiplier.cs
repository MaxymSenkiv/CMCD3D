using System;
using TMPro;
using UnityEngine;

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

    private void OnEnable()
    {
        _amountChanger.Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        _amountChanger.Triggered -= OnTriggered;
    }

    private void OnTriggered(PlayerGroup playerGroup)
    {
        if (!_amountChanger.Multiplied)
        {
            _amountChanger.Multiplied = true;
            StartCoroutine(playerGroup.SpawnUnits(playerGroup._unitsGroup.Count * (_multiplier - 1)));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Stickman>(out Stickman stickman) && !_amountChanger.Multiplied)
        {
            _amountChanger.Triggered.Invoke(stickman.transform.parent.GetComponent<PlayerGroup>());
        }
    }
}
