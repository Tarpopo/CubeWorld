using System;
using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour, IResourceUI
{
    public ResourceType ResourceType => _resourceType;
    public bool HaveResource => _currentCount > 0;
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private TMP_Text _resourceCount;
    private const int MaxResourceCount = 999;
    private int _currentCount;

    public void AddResourceValue(int value)
    {
        if (value <= 0 || _currentCount >= MaxResourceCount) return;
        _currentCount = Math.Clamp(value + _currentCount, 0, MaxResourceCount);
        UpdateText();
    }

    public void RemoveResourceValue(int value)
    {
        if (value <= 0 || _currentCount <= 0) return;
        _currentCount = Math.Clamp(_currentCount - value, 0, MaxResourceCount);
        UpdateText();
    }

    private void Start() => UpdateText();

    private void UpdateText() => _resourceCount.text = _currentCount.ToString();
}