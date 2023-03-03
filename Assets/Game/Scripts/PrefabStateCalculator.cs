using System;
using UnityEngine;

[Serializable]
public class PrefabStateCalculator
{
    [SerializeField] private GameObject[] _prefabsStates;
    private float _delta;

    public void TrySetState(int hitsLeft)
    {
        _prefabsStates.DisableAll();
        if (hitsLeft <= 0) return;
        var stateIndex = Mathf.Ceil(hitsLeft * _delta) - 1;
        _prefabsStates[(int)stateIndex].Enable();
        Debug.Log(stateIndex);
    }

    public void SetParameters(int maxHitsToDestroy)
    {
        _delta = (float)_prefabsStates.Length / maxHitsToDestroy;
        TrySetState(maxHitsToDestroy);
    }
}