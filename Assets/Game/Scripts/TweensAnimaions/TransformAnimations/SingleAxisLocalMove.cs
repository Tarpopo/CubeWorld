using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class SingleAxisLocalMove : BaseTweenAnimation
{
    [SerializeField] private Axis _axis;
    [SerializeField] private float _endValue;
    [SerializeField] private float _startValue;
    [SerializeReference] private IMoveTransformTween _moveTween;

    public override void SetStartValues() => _moveTween.SetLocalAxisPosition(_axis, _startValue);

    public override void SetEndValues() => _moveTween.SetLocalAxisPosition(_axis, _endValue);

    public override Tween GetTween() => _moveTween.GetLocalAxisMoveTween(_axis, _endValue, Duration);
}