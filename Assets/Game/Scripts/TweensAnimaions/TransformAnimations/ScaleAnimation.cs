using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class ScaleAnimation : BaseTweenAnimation
{
    [SerializeField] private Vector3 _endScale;
    [SerializeField] private Vector3 _startScale;
    [SerializeReference] public IScaleTween _scaleTween;
    public override void SetStartValues() => _scaleTween.SetScaleValue(_startScale);

    public override void SetEndValues() => _scaleTween.SetScaleValue(_startScale);

    public override Tween GetTween() => _scaleTween.GetScaleTween(_endScale, Duration);
}