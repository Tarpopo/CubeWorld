using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public abstract class MinMaxValue<T>
{
    public T Value => GetValue();
    [SerializeField] protected T _minValue;
    [SerializeField] protected T _maxValue;
    protected abstract T GetValue();
}

[Serializable]
public class IntRandomValue : MinMaxValue<int>
{
    protected override int GetValue() => Random.Range(_minValue, _maxValue);
}

[Serializable]
public class FloatRandomValue : MinMaxValue<float>
{
    protected override float GetValue() => Random.Range(_minValue, _maxValue);
}