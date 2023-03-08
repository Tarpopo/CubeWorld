using System;
using System.Collections;
using UnityEngine;

public class ValueRestorer
{
    public event Action OnValueRestore;
    private readonly Action _onValueTick;
    private readonly Func<bool> _activeCondition;
    private readonly float _restoreTick;
    private Coroutine _coroutine;

    public ValueRestorer(float restoreTick, Func<bool> activeCondition, Action onValueTick)
    {
        _activeCondition = activeCondition;
        _restoreTick = restoreTick;
        _onValueTick = onValueTick;
    }

    public void StartValueRestoring(MonoBehaviour monoBehaviour)
    {
        if (_coroutine != null) monoBehaviour.StopCoroutine(_coroutine);
        _coroutine = monoBehaviour.StartCoroutine(RestoreCoroutine());
    }

    private IEnumerator RestoreCoroutine()
    {
        while (_activeCondition.Invoke())
        {
            yield return new WaitForSeconds(_restoreTick);
            _onValueTick?.Invoke();
        }

        OnValueRestore?.Invoke();
    }
}