using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class ColorAnimation : BaseTweenAnimation
{
    [SerializeField] private Color _startValue;
    [SerializeField] private Color _endValue;
    [SerializeReference] private IColorTween _color;

    public override Tween GetTween() => _color.GetTween(_endValue, Duration);

    public override void SetStartValues() => _color.SetColor(_startValue);

    public override void SetEndValues() => _color.SetColor(_endValue);
}