using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker<T>
{
    public bool HaveElements => Elements.Count > 0;

    public List<T> Elements { get; private set; } = new List<T>(5);

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<T>(out var component) == false) return;
        if (Elements.Contains(component)) return;
        Elements.Add(component);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<T>(out var component) == false) return;
        if (Elements.Contains(component)) Elements.Remove(component);
    }
}