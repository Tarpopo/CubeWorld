using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class TransformTween : IMoveTransformTween, IPunchTransformTween, IScaleTween
{
    [SerializeField] private Transform _transform;

    public Tween GetMoveTween(Vector3 endValue, float duration) => _transform.DOMove(endValue, duration);

    public Tween GetLocalMoveTween(Vector3 endValue, float duration) => _transform.DOLocalMove(endValue, duration);

    public Tween GetPunchScaleTween(Vector3 value, float duration, int vibrato, float elasticity) =>
        _transform.DOPunchScale(value, duration, vibrato, elasticity);

    public Tween GetPunchRotationTween(Quaternion value, float duration, int vibrato, float elasticity) =>
        _transform.DOPunchRotation(value.eulerAngles, duration, vibrato, elasticity);

    public Tween GetScaleTween(Vector3 endValue, float duration) => _transform.DOScale(endValue, duration);

    public Tween GetAxisMoveTween(Axis axis, float value, float duration)
    {
        return axis switch
        {
            Axis.X => _transform.DOMoveX(value, duration),
            Axis.Y => _transform.DOMoveY(value, duration),
            Axis.Z => _transform.DOMoveZ(value, duration),
            _ => _transform.DOMoveX(value, duration)
        };
    }

    public Tween GetLocalAxisMoveTween(Axis axis, float value, float duration)
    {
        return axis switch
        {
            Axis.X => _transform.DOLocalMoveX(value, duration),
            Axis.Y => _transform.DOLocalMoveY(value, duration),
            Axis.Z => _transform.DOLocalMoveZ(value, duration),
            _ => _transform.DOLocalMoveX(value, duration)
        };
    }

    public void SetAxisPosition(Axis axis, float value) =>
        _transform.position = _transform.position.AddAxis(axis, value);

    public void SetLocalAxisPosition(Axis axis, float value) =>
        _transform.localPosition = _transform.localPosition.AddAxis(axis, value);

    public void SetPosition(Vector3 value) => _transform.position = value;

    public void SetLocalPosition(Vector3 value) => _transform.localPosition = value;

    public void SetScaleValue(Vector3 value) => _transform.localScale = value;
}