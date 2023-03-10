using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class LocalMoveAnimation : BaseTweenAnimation
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private Vector3 _startPosition;
    [SerializeReference] private IMoveTransformTween _moveTransformTween;

    public override void SetStartValues() => _moveTransformTween.SetLocalPosition(_startPosition);

    public override void SetEndValues() => _moveTransformTween.SetLocalPosition(_startPosition);

    public override Tween GetTween() => _moveTransformTween.GetLocalMoveTween(_endPosition, Duration);
}