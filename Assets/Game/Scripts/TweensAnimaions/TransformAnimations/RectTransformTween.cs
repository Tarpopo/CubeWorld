using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;

[Serializable]
public class RectMoveTransformTween : IMoveTransformTween, IPunchTransformTween, IScaleTween
{
    [SerializeField] private RectTransform _rectTransform;

    public Tween GetMoveTween(Vector3 endValue, float duration) => _rectTransform.DOAnchorPos(endValue, duration);

    public Tween GetLocalMoveTween(Vector3 endValue, float duration) => _rectTransform.DOLocalMove(endValue, duration);

    public Tween GetPunchScaleTween(Vector3 value, float duration, int vibrato, float elasticity) =>
        _rectTransform.DOPunchAnchorPos(value, duration, vibrato, elasticity);

    public Tween GetPunchRotationTween(Quaternion value, float duration, int vibrato, float elasticity) =>
        _rectTransform.DOPunchRotation(value.eulerAngles, duration, vibrato, elasticity);

    public Tween GetScaleTween(Vector3 endValue, float duration) => _rectTransform.DOScale(endValue, duration);

    public Tween GetAxisMoveTween(Axis axis, float value, float duration)
    {
        return axis switch
        {
            Axis.X => _rectTransform.DOAnchorPosX(value, duration),
            Axis.Y => _rectTransform.DOAnchorPosY(value, duration),
            Axis.Z => _rectTransform.DOAnchorPos3DZ(value, duration),
            _ => _rectTransform.DOAnchorPosX(value, duration)
        };
    }

    public Tween GetLocalAxisMoveTween(Axis axis, float value, float duration)
    {
        return axis switch
        {
            Axis.X => _rectTransform.DOLocalMoveX(value, duration),
            Axis.Y => _rectTransform.DOLocalMoveY(value, duration),
            Axis.Z => _rectTransform.DOLocalMoveZ(value, duration),
            _ => _rectTransform.DOLocalMoveX(value, duration)
        };
    }

    public void SetAxisPosition(Axis axis, float value) =>
        _rectTransform.anchoredPosition = _rectTransform.anchoredPosition3D.AddAxis(axis, value);

    public void SetLocalAxisPosition(Axis axis, float value) =>
        _rectTransform.localPosition = _rectTransform.localPosition.AddAxis(axis, value);

    public void SetPosition(Vector3 value) => _rectTransform.anchoredPosition = value;

    public void SetScaleValue(Vector3 value) => _rectTransform.localScale = value;

    public void SetLocalPosition(Vector3 value) => _rectTransform.localPosition = value;
}