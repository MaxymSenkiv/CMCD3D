using TMPro;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private TextMeshProUGUI _startText;
    
    private void Update()
    {
    }

    private void Awake()
    {
        _startText.enabled = true;
        _startText.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _startText.enabled = false;
    }
}
