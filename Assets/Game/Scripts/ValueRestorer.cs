using System;
using System.Collections;
using UnityEngine;

public class ValueRestorer
{
    public event Action OnValueRestore;
    private Action _onValueTick;
    private Func<bool> _activeCondition;
    private Coroutine _coroutine;
    private float _restoreTick;

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