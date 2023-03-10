using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class SingleAxisMoveAnimation : BaseTweenAnimation
{
    [SerializeField] private Axis _axis;
    [SerializeField] private float _endValue;
    [SerializeField] private float _startValue;
    [SerializeReference] private IMoveTransformTween _moveTween;

    public override void SetStartValues() => _moveTween.SetAxisPosition(_axis, _startValue);

    public override void SetEndValues() => _moveTween.SetAxisPosition(_axis, _endValue);

    public override Tween GetTween() => _moveTween.GetAxisMoveTween(_axis, _endValue, Duration);
}