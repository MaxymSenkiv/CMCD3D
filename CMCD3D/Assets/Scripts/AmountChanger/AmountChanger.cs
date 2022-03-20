using UnityEngine;
using UnityEngine.Events;

public class AmountChanger : MonoBehaviour
{
    public UnityAction<PlayerUnitsController, int> Triggered;
    public bool Multiplied;
    
    private void OnEnable()
    {
        Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        Triggered -= OnTriggered;
    }

    private void OnTriggered(PlayerUnitsController playerUnitsController, int multiplier)
    {
        if (!Multiplied)
        {
            Multiplied = true;
            playerUnitsController.SpawnUnits(playerUnitsController.UnitsGroup.Count * (multiplier - 1), playerUnitsController.AverageUnitsPosition, true);
        }
    }
}
