using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class MoveAnimation : BaseTweenAnimation
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private Vector3 _startPosition;
    [SerializeReference] private IMoveTransformTween _moveTransformTween;

    public override void SetStartValues() => _moveTransformTween.SetPosition(_startPosition);

    public override void SetEndValues() => _moveTransformTween.SetPosition(_startPosition);

    public override Tween GetTween() => _moveTransformTween.GetMoveTween(_endPosition, Duration);
}