using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AmountChanger : MonoBehaviour
{
    public UnityAction<PlayerGroup, int> Triggered;
    public bool Multiplied;
    
    private void OnEnable()
    {
        Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        Triggered -= OnTriggered;
    }

    private void OnTriggered(PlayerGroup playerGroup, int multiplier)
    {
        if (!Multiplied)
        {
            Multiplied = true;
            StartCoroutine(playerGroup.SpawnUnits(playerGroup.UnitsGroup.Count * (multiplier - 1),
                                                        playerGroup.SpawnPoint,
                                                        true));
        }
    }
}
