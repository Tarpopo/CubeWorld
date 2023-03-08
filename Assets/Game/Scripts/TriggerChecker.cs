using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerChecker<T>
{
    public event Action<T> OnObjectEnter;
    public event Action<T> OnObjectExit;
    public bool HaveElements => _elementsDictionary.Count > 0;

    public IEnumerable<T> Elements => _elementsDictionary.Values;
    public T First => Elements.First();

    private readonly Dictionary<int, T> _elementsDictionary = new Dictionary<int, T>(20);

    public void OnTriggerEnter(Collider other) => TryAddItem(other.gameObject);

    public void OnTriggerStay(Collider other) => TryAddItem(other.gameObject);

    public void OnTriggerExit(Collider other) => TryRemoveItem(other.gameObject);

    public void TryRemoveItem(GameObject gameObject)
    {
        var hashCode = gameObject.GetHashCode();
        if (_elementsDictionary.ContainsKey(hashCode) == false) return;
        _elementsDictionary.Remove(hashCode);
        OnObjectExit?.Invoke(_elementsDictionary[hashCode]);
    }

    private void TryAddItem(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<T>(out var component) == false) return;
        var hashCode = gameObject.GetHashCode();
        if (_elementsDictionary.ContainsKey(hashCode)) return;
        _elementsDictionary.Add(hashCode, component);
        OnObjectEnter?.Invoke(component);
    }
}