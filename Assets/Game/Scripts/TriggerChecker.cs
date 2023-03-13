using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerChecker<T>
{
    public event Action<T> OnObjectEnter;
    public event Action<T> OnObjectExit;
    public bool HaveElements => _elements.Count > 0;
    public IEnumerable<T> Elements => _elements;
    public T First => _elements.First();

    private readonly HashSet<T> _elements = new HashSet<T>(50);

    public void OnTriggerEnter(Collider other) => TryAddItem(other.gameObject);

    public void OnTriggerStay(Collider other) => TryAddItem(other.gameObject);

    public void OnTriggerExit(Collider other) => TryRemoveItem(other.gameObject);

    public void TryRemoveItem(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<T>(out var component) == false || _elements.Contains(component) == false) return;
        _elements.Remove(component);
        OnObjectExit?.Invoke(component);
    }

    private void TryAddItem(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<T>(out var component) == false || _elements.Contains(component)) return;
        _elements.Add(component);
        OnObjectEnter?.Invoke(component);
    }
}