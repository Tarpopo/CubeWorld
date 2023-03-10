using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class SpriteRendererColorAnimation : IColorTween
{
    public Color Color => _spriteRenderer.color;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SetColor(Color color) => _spriteRenderer.color = color;

    public Tween GetTween(Color color, float duration) => _spriteRenderer.DOColor(color, duration);
}