using System;
using UnityEngine;

[Serializable]
public class PrefabStateCalculator
{
    [SerializeField] private bool _allActive;
    private GameObject[] _prefabsStates;
    private float _delta;

    public void TrySetState(int hitsLeft)
    {
        _prefabsStates.DisableAll();
        if (hitsLeft <= 0) return;
        var stateIndex = Mathf.CeilToInt(hitsLeft * _delta) - 1;
        if (_allActive)
        {
            for (int i = 0; i < stateIndex + 1; i++)
            {
                _prefabsStates[i].Enable();
            }
        }
        else
        {
            _prefabsStates[stateIndex].Enable();
        }
    }

    public void SetParameters(int maxHitsToDestroy, GameObject[] prefabsStates)
    {
        _prefabsStates = prefabsStates;
        _delta = (float)_prefabsStates.Length / maxHitsToDestroy;
        TrySetState(maxHitsToDestroy);
    }
}