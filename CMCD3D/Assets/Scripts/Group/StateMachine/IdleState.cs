using TMPro;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private TextMeshProUGUI _startText;
    
    private void Update()
    {
    }

    private void OnDisable()
    {
        _startText.enabled = false;
    }
}
