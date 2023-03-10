using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class MaterialColorAnimation : IColorTween
{
    public Color Color => _material.color;
    [SerializeField] private Material _material;

    public void SetColor(Color color) => _material.color = color;

    public Tween GetTween(Color color, float duration) => _material.DOColor(color, duration);
}