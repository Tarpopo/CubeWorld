using DG.Tweening;
using UnityEngine;

public interface IScaleTween
{
    Tween GetScaleTween(Vector3 endValue, float duration);
    public void SetScaleValue(Vector3 value);
}
