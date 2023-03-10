using System;
using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour, IResourceUI
{
    public ResourceType ResourceType => _resourceType;
    public bool HaveResource => _currentCount.Value > 0;
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private TMP_Text _resourceCount;
    [SerializeReference] private BaseTweenAnimation _scale;
    private const int MaxResourceCount = 999;
    private SavableInt _currentCount;
    public void Enable() => gameObject.Enable();

    public void Disable() => gameObject.Disable();

    public void AddResourceValue(int value)
    {
        if (value <= 0 || _currentCount.Value >= MaxResourceCount) return;
        _currentCount.Value = Math.Clamp(value + _currentCount.Value, 0, MaxResourceCount);
        UpdateText();
    }

    public void RemoveResourceValue(int value)
    {
        if (value <= 0 || _currentCount.Value <= 0) return;
        _currentCount.Value = Math.Clamp(_currentCount.Value - value, 0, MaxResourceCount);
        UpdateText();
        if (_currentCount.Value <= 0) gameObject.Disable();
    }

    private void Start()
    {
        _currentCount = new SavableInt(_resourceType.ToString(), FindObjectOfType<JSONSaver>());
        if (_currentCount.Value <= 0) Disable();
        UpdateText();
    }

    private void UpdateText()
    {
        _resourceCount.text = _currentCount.Value.ToString();
        _scale.PlayAnimation();
    }
}