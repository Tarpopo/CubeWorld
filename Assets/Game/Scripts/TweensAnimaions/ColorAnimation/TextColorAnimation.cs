using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

[Serializable]
public class TextColor : IColorTween
{
    public Color Color => _text.color;
    [SerializeField] private TMP_Text _text;
    public void SetColor(Color color) => _text.color = color;
    public Tween GetTween(Color color, float duration) => _text.DOColor(color, duration);
}